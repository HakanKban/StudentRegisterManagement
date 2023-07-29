using AutoMapper;
using StudentRegisterManagement.Core;
using StudentRegisterManagement.Core.Dtos;
using StudentRegisterManagement.Core.Entities;
using StudentRegisterManagement.Core.Interfaces;

namespace StudentRegisterManagement.Service
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponse<NoContent>> CreateStudentAsync(StudentCreateDTO studentCreateDTO)
        {
            Student student = _mapper.Map<Student>(studentCreateDTO);
            if (studentCreateDTO.LessonCreateDTOs != null) // Öğrenci ile ilişkilendirilmek istenen dersler boş değil ise.
            {
                student.StudentLessons = new();
                foreach (var lessonCreate in studentCreateDTO.LessonCreateDTOs)
                // Dersler için nesne yaratılarak student entity'sinde ilgili alana setlenir
                {
                    Lesson lesson = _mapper.Map<Lesson>(lessonCreate);
                    student.StudentLessons.Add(new StudentLesson() { Lesson = lesson });
                    if (lessonCreate.NotesCreateDTOs != null) // Derslere ait not eklenebilir.
                    {
                        lesson.Notes = new();
                        foreach (var notesCreate in lessonCreate.NotesCreateDTOs)
                        {
                            Notes notes = _mapper.Map<Notes>(notesCreate);
                            lesson.Notes.Add(notes);
                        }
                    }
                }
            }
            await _unitOfWork.StudentRepository.CreateAsync(student);
            await _unitOfWork.SaveAsync();

            return CustomResponse<NoContent>.Success(200);
        }

        public async Task<CustomResponse<NoContent>> DeleteStudentAsync(Guid Id)
        {
            Student student = await _unitOfWork.StudentRepository.GetByIdAsync(Id);
            if (student == null)
            {
                return CustomResponse<NoContent>.Fail(404, "Öğrenci Bulunamadı");
            }
            await _unitOfWork.StudentRepository.DeleteAsync(student);
            await _unitOfWork.SaveAsync();
            return CustomResponse<NoContent>.Success(200);
        }

        public async Task<CustomResponse<List<StudentDTO>>> GetAllStudent()
        {
            List<Student> students = await _unitOfWork.StudentRepository.GetAllAsync(); //Tüm Öğrenciler listelenir.
            if (students == null) //Öğrenci yok ise hata mesaı dönülür.
            {
                return CustomResponse<List<StudentDTO>>.Fail(404, "Öğrenci Bulunamadı");
            }

            List<StudentDTO> resStudents = _mapper.Map<List<StudentDTO>>(students);
            int totalAlan = resStudents.First().GetType().GetProperties().Count() - 1; //TotalRate alanı her entityde olduğu için çıkarılmıştır.
            foreach (var studentDto in resStudents)
            {
                int doluAlanlar = studentDto.GetType().GetProperties().Select(x => x.GetValue(studentDto, null)).Where(x => x != null).Count();
                studentDto.ProfileRate = (doluAlanlar*100)/ totalAlan;
            }
            resStudents = resStudents.OrderByDescending(x => x.ProfileRate).ToList();//BüyükTen küçüğe sıralama işlemi.
            return CustomResponse<List<StudentDTO>>.Success(200, resStudents);
        }

        public async Task<CustomResponse<NoContent>> UpdateStudentAsync(StudentUpdateDTO studentUpdate)
        {
            bool IsExist = await _unitOfWork.StudentRepository.AnyAsync(x => x.Id == studentUpdate.Id);
            if (IsExist == false)
            {
                return CustomResponse<NoContent>.Fail(404, "Öğrenci Bulunamadı");
            }

            Student student = _mapper.Map<Student>(studentUpdate);
            await _unitOfWork.StudentRepository.UpdateAsync(student);
            await _unitOfWork.SaveAsync();
            return CustomResponse<NoContent>.Success(200);
        }
    }
}

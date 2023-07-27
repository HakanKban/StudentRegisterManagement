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
            if (studentCreateDTO.LessonCreateDTOs != null)
            {
                student.StudentLessons = new();
                foreach (var lessonCreate in studentCreateDTO.LessonCreateDTOs)
                {
                    Lesson lesson = _mapper.Map<Lesson>(lessonCreate);
                    student.StudentLessons.Add(new StudentLesson() { Lesson = lesson });
                    if (lessonCreate.NotesCreateDTOs != null)
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
                CustomResponse<NoContent>.Fail(404, "Öğrenci Bulunamadı");
            }
            await _unitOfWork.StudentRepository.DeleteAsync(student);
            await _unitOfWork.SaveAsync();
            return CustomResponse<NoContent>.Success(200);
        }

        public Task<CustomResponse<NoContent>> GetAllStudent()
        {
            throw new NotImplementedException();
        }

        public async Task<CustomResponse<NoContent>> UpdateStudentAsync(StudentUpdateDTO studentUpdate)
        {
            bool IsExist = await _unitOfWork.StudentRepository.AnyAsync(x => x.Id == studentUpdate.Id);
            if (IsExist == false)
            {
                CustomResponse<NoContent>.Fail(404, "Öğrenci Bulunamadı");
            }

            Student student = _mapper.Map<Student>(studentUpdate);
            await _unitOfWork.StudentRepository.UpdateAsync(student);
            await _unitOfWork.SaveAsync();
            return CustomResponse<NoContent>.Success(200);
        }
    }
}

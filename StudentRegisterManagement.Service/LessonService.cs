using AutoMapper;
using StudentRegisterManagement.Core;
using StudentRegisterManagement.Core.Dtos;
using StudentRegisterManagement.Core.Entities;
using StudentRegisterManagement.Core.Interfaces;

namespace StudentRegisterManagement.Service
{
    public class LessonService : ILessonService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public LessonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomResponse<NoContent>> CreateLessonAsync(LessonCreateDTO lessonCreateDTO)
        {
            Lesson lesson = _mapper.Map<Lesson>(lessonCreateDTO);

            if (lessonCreateDTO.StudentId != null) //Öğrenci Id verildi ise o ders ile ilşkilendirilir.
            {
                lesson.StudentLesson = new();
                lesson.StudentLesson.Add(new StudentLesson() { StudentId = (Guid)lessonCreateDTO.StudentId });
            }
           

            if (lessonCreateDTO.NotesCreateDTOs != null) // Derse ait notlar eklenir.
            {
                lesson.Notes = new();
                foreach (var notesCreate in lessonCreateDTO.NotesCreateDTOs)
                {
                    Notes notes = _mapper.Map<Notes>(notesCreate);
                    lesson.Notes.Add(notes);
                }
            }
            await _unitOfWork.LessonRepository.CreateAsync(lesson);
            await _unitOfWork.SaveAsync();
            return CustomResponse<NoContent>.Success(200);
        }

        public async Task<CustomResponse<NoContent>> DeleteLessonAsync(Guid Id)
        {
            Lesson lesson = await _unitOfWork.LessonRepository.GetByIdAsync(Id);
            if (lesson == null)
            {
               return CustomResponse<NoContent>.Fail(404, "Ders Bulunamadı");
            }
            await _unitOfWork.LessonRepository.DeleteAsync(lesson);
            await _unitOfWork.SaveAsync();
            return CustomResponse<NoContent>.Success(200);
        }

        public async Task<CustomResponse<NoContent>> UpdateLessonAsync(LessonUpdateDTO lessonUpdate)
        {
            bool IsExist = await _unitOfWork.LessonRepository.AnyAsync(x => x.Id == lessonUpdate.Id);
            if (IsExist == false)
            {
                return CustomResponse<NoContent>.Fail(404, "Öğrenci Bulunamadı");
            }

            Lesson lesson = _mapper.Map<Lesson>(lessonUpdate);
            await _unitOfWork.LessonRepository.UpdateAsync(lesson);
            await _unitOfWork.SaveAsync();
            return CustomResponse<NoContent>.Success(200);
        }
    }
}

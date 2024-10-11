using AutoMapper;
using TaskManagerApi.Data;
using TaskManagerApi.Data.Models;
using TaskManagerApi.Service.Interfaces;
using TaskManagerApi.ViewModels;

namespace TaskManagerApi.Service
{
    public class TaskService : ITaskService
    {
        private readonly IRepository<TbTask> _repository;
        private readonly IMapper _mapper;
        public TaskService(IRepository<TbTask> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskModel>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TaskModel>>(result);
        }
        public async Task<TaskModel> GetById(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            return _mapper.Map<TaskModel>(result);
        }
        public async Task<int> AddAsync(TaskModel obj)
        {
            var entity = _mapper.Map<TbTask>(obj);
            return await _repository.AddAsync(entity);
        }
        public async Task<int> UpdateAsync(int id, TaskModel obj)
        {
            if (await _repository.Exists(id)) throw new ArgumentException($"Task ID {id} não existe.");

            var entity = _mapper.Map<TbTask>(obj);
            return await _repository.Update(entity);
        }
        public async Task<int> DeleteAsync(int id)
        {
            if (await _repository.Exists(id)) throw new ArgumentException($"Task ID {id} não existe.");

            return await _repository.Delete(id);
        }
    }
}
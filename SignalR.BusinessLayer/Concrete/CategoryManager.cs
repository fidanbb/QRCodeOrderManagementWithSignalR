using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

		public async Task<int> TActiveCategoryCountAsync()
		{
			return await _categoryDal.ActiveCategoryCountAsync();
		}

		public async Task TAdd(Category entity)
        {
            await _categoryDal.Add(entity); 
        }

		public async Task<int> TCategoryCount()
		{
			return await _categoryDal.CategoryCount();
		}

		public async Task TDelete(Category entity)
        {
            await _categoryDal.Delete(entity);
        }

        public async Task<List<Category>> TGetAll()
        {
            return await _categoryDal.GetAll();
        }

        public async Task<Category> TGetByID(int id)
        {
            return await _categoryDal.GetByID(id);
        }

		public async Task<int> TPassiveCategoryCountAsync()
		{
			return await _categoryDal.PassiveCategoryCountAsync();
		}

		public async Task TUpdate(Category entity)
        {
           await _categoryDal.Update(entity);   
        }
    }
}

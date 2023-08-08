﻿using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Result.IngredientCategoryResult;
using Microsoft.AspNetCore.Mvc;

namespace CookingMasterAPI.Services.ServiceInterfaces
{
    public interface IIngredientCategoryService
    {
        Task<GetIngredientCategoriesResult> GetIngredientCategoriesAsync();
        Task<GetIngredientCategoryResult> GetIngredientCategoryAsync(int categoryId);
    }
}
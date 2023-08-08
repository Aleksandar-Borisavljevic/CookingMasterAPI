﻿using CookingMasterAPI.Enums.IngCategoryStatusEnums;
using CookingMasterAPI.Models.Entity;
using CookingMasterAPI.Models.Response;

namespace CookingMasterAPI.Models.Result.IngredientCategoryResult
{
    public class GetIngredientCategoriesResult : BaseResult<GetIngredientCategoriesEnum>
    {
        public GetIngredientCategoriesResult
            (
            GetIngredientCategoriesEnum status,
            string description,
            IEnumerable<IngredientCategoryResponse>? ingredientCategories
            )
            : base(status, description)
        {
            IngredientCategories = ingredientCategories;
        }

        public IEnumerable<IngredientCategoryResponse>? IngredientCategories { get; set; }
    }
}
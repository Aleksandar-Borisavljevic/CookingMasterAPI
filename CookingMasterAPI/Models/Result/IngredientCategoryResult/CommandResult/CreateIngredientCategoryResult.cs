﻿using CookingMasterAPI.Enums.IngCategoryStatusEnums.CommandEnums;

namespace CookingMasterAPI.Models.Result.IngredientCategoryResult.CommandResult
{
    public class UpdateIngredientCategoryResult : BaseResult<UpdateIngredientCategoryEnum>
    {
        public UpdateIngredientCategoryResult(UpdateIngredientCategoryEnum status, string description)
            : base(status, description)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookingMasterApi.Application.Common.Models;

namespace CookingMasterApi.Application.Common.Interfaces;
public interface IIngredientCategoryService
{
    string CreateIngredientCategory(UserInfo user);
}

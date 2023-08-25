namespace CookingMasterAPI.Models.Response
{
    public record UserResponse
        (
            string Username,
            string EmailAddress,
            IEnumerable<IngredientResponse> Ingredients,
            string UserUid
        );
}

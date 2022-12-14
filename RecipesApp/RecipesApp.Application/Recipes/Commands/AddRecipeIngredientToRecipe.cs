using MediatR;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.Commands
{
    public class AddRecipeIngredientToRecipe : IRequest<Recipe>
    {
        public int RecipeId { get; set; }
        public int RecipeIngredientId { get; set; }
    }
}
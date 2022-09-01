﻿namespace RecipesApp.Application.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        public IIngredientRepository IngredientRepository { get; }
        public IIngredientImageRepository IngredientImageRepository { get; }
        public IRecipeIngredientRepository RecipeIngredientRepository { get; }
        public IRecipeRepository RecipeRepository { get; }
        public IRecipeWithRecipeIngredientsRepository RecipeWithRecipeIngredientsRepository { get; }
        public IRecipeImageRepository RecipeImageRepository { get; }
        public IMealPlanRepository MealPlanRepository { get; }
        Task Save();
    }
}

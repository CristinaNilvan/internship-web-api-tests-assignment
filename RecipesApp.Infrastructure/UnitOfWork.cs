﻿using RecipesApp.Application.Abstractions;
using RecipesApp.Infrastructure.Context;

namespace RecipesApp.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext, IIngredientRepository ingredientRepository,
            IIngredientImageRepository ingredientImageRepository,
            IRecipeIngredientRepository recipeIngredientRepository, IRecipeRepository recipeRepository,
            IRecipeWithRecipeIngredientsRepository recipeWithRecipeIngredientsRepository,
            IRecipeImageRepository recipeImageRepository, IMealPlanRepository mealPlanRepository)
        {
            _dataContext = dataContext;
            IngredientRepository = ingredientRepository;
            IngredientImageRepository = ingredientImageRepository;
            RecipeIngredientRepository = recipeIngredientRepository;
            RecipeRepository = recipeRepository;
            RecipeWithRecipeIngredientsRepository = recipeWithRecipeIngredientsRepository;
            RecipeImageRepository = recipeImageRepository;
            MealPlanRepository = mealPlanRepository;
        }

        public IIngredientRepository IngredientRepository { get; private set; }

        public IIngredientImageRepository IngredientImageRepository { get; private set; }

        public IRecipeIngredientRepository RecipeIngredientRepository { get; private set; }

        public IRecipeRepository RecipeRepository { get; private set; }

        public IRecipeWithRecipeIngredientsRepository RecipeWithRecipeIngredientsRepository { get; private set; }

        public IRecipeImageRepository RecipeImageRepository { get; }

        public IMealPlanRepository MealPlanRepository { get; private set; }

        public async Task Save()
        {
            await _dataContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}

﻿using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.SuggestRecipesFeature.Queries;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.SuggestRecipesFeature.QueryHandlers
{
    public class SuggestRecipesHandler : IRequestHandler<SuggestRecipes, List<Recipe>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SuggestRecipesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Recipe>> Handle(SuggestRecipes request, CancellationToken cancellationToken)
        {
            var quantityTwoDecimals = RecipesSuggesterUtils.CalculateTwoDecimalFloat(request.IngredientQuantity);

            var allRecipes = await _unitOfWork
                .RecipeRepository
                .GetByApprovedStatus(true);
            var recipesWithIngredient = await _unitOfWork
                .RecipeRepository
                .GetRecipesWithInredientAndQuantity(quantityTwoDecimals, request.IngredientName);
            var bestMatches = await _unitOfWork
                .RecipeRepository
                .GetBestMatchRecipesWithInredientAndQuantity(quantityTwoDecimals, request.IngredientName);

            if (bestMatches.Count != 0)
            {
                return bestMatches;
            }
            else if (recipesWithIngredient.Count != 0)
            {
                return recipesWithIngredient;
            }
            else
            {
                return allRecipes;
            }
        }
    }
}

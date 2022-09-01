﻿using MediatR;
using RecipesApp.Application.Abstractions;
using RecipesApp.Application.Recipes.Commands;
using RecipesApp.Domain.Models;

namespace RecipesApp.Application.Recipes.CommandHandlers
{
    public class RemoveImageFromRecipeHandler : IRequestHandler<RemoveImageFromRecipe, Recipe>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBlobService _blobService;

        public RemoveImageFromRecipeHandler(IUnitOfWork unitOfWork, IBlobService blobService)
        {
            _unitOfWork = unitOfWork;
            _blobService = blobService;
        }

        public async Task<Recipe> Handle(RemoveImageFromRecipe request, CancellationToken cancellationToken)
        {
            var recipe = await _unitOfWork.RecipeRepository.GetById(request.RecipeId);
            var recipeImage = await _unitOfWork.RecipeImageRepository.GetByRecipeId(request.RecipeId);

            if (recipe == null || recipeImage == null)
            {
                return null;
            }

            var recipeNameAndAuthor = recipe.Name + " " + recipe.Author;
            var fileName = recipeNameAndAuthor.Replace(" ", "_").ToLower();

            await _blobService.DeleteBlob(fileName, request.ContainerName);
            await _unitOfWork.RecipeImageRepository.Delete(recipeImage);
            await _unitOfWork.Save();

            return recipe;
        }
    }
}

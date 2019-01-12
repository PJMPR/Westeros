select r.Name, i.Name, ri.IngredientQuantity
from Recipes r
join RecipeIngredients ri on r.id = ri.RecipeId
join Ingredients i on i.id = ri.IngredientId

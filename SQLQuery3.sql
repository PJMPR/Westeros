select r.Name, d.Name
from Recipes r
join RecipeDevice rd on r.id = rd.RecipeId
join Devices d on d.id = rd.DeviceId
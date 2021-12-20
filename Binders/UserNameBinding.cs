using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

/*
    - Convert name to UPPERCASE
    - Name is not contains XXX
    - Trim name
*/
public class UserNameBinding : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException("bindingContext");
        }

        string modelName = bindingContext.ModelName;

        // Read value
        var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
        if (valueProviderResult == ValueProviderResult.None)
        {
            return Task.CompletedTask;
        }

        string value = valueProviderResult.FirstValue;
        if (string.IsNullOrEmpty(value))
        {
            return Task.CompletedTask;
        }

        // Binding
        string s = value.ToUpper();

        if (s.Contains("XXX"))
        {
            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);
            bindingContext.ModelState.TryAddModelError(modelName, "Error: Contains XXX");
            return Task.CompletedTask;
        }

        s = s.Trim();
        bindingContext.ModelState.SetModelValue(modelName, s, s);
        bindingContext.Result = ModelBindingResult.Success(s);
        return Task.CompletedTask;
    }
}
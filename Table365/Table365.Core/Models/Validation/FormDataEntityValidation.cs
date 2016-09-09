using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Table365.Core.Models.Validation
{
    public class FormDataEntityValidation
    {
        public static void ValidateEntity<TEntity>(TEntity entity)
        {
            var vc = new ValidationContext(entity, null, null);
            var vcResult = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(entity, vc, vcResult, true);
            if (isValid) return;

            var errorMsg = new Dictionary<string, string> {{"error", string.Join("\n", vcResult)}};
            var msg = JsonConvert.SerializeObject(errorMsg);
            throw new ValidationException(msg);
        }
    }
}
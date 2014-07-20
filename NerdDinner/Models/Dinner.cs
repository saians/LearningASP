using System;
using System.Collections.Generic;
using System.Linq;

namespace NerdDinner.Models
{
    public partial class Dinner
    {
        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        private IEnumerable<RuleViolation> GetRuleViolations()
        {
            yield break;
        }

        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if (!IsValid)
                throw new ApplicationException("Rule violation prevent saving");
        }

    }

    public class RuleViolation
    {
        public string ErrorMessage { get; private set; }
        protected string PropertyName { get; set; }

        public RuleViolation(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public RuleViolation(string errorMessage, string propertyName)
        {
            ErrorMessage = errorMessage;
            PropertyName = propertyName;
        }
    }
}
using System.Collections.Generic;

namespace nothinbutdotnetprep.infrastructure.searching
{
    public class CriteriaFactory<ItemToSearch, PropertyType>
    {
        PropertyAccessor<ItemToSearch, PropertyType> accessor;

        public CriteriaFactory(PropertyAccessor<ItemToSearch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToSearch> equal_to(PropertyType value)
        {
            return equal_to_any(value);
        }

        public Criteria<ItemToSearch> equal_to_any(params PropertyType[] values)
        {
            return new AnonymousCriteria<ItemToSearch>(x => new List<PropertyType>(values).Contains(accessor(x)));
        }
    }
}
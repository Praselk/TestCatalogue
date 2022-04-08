using TestCatalogue.BLL.Interfaces;
using TestCatalogue.Interfaces;

namespace TestCatalogue.Helpers
{
    public static class CollectionHelper
    {
        public static List<TTarget> PopulateModels<TSource, TTarget>(IDTORepository<TSource> sourceRep)
            where TSource : class
            where TTarget : IAssignable<TSource>, new()
        {
            IList<TSource> sources = sourceRep.GetAll();
            List<TTarget> models = new List<TTarget>();

            foreach (TSource source in sources)
            {
                TTarget model = new TTarget();
                model.AssignFrom(source);
                models.Add(model);
            }

            return models;
        }
    }
}

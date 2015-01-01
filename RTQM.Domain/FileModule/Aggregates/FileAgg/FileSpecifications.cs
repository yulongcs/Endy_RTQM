using Lgsoft.SF.Domain.Specification;

namespace Lgsoft.RTQM.Domain.FileModule.Aggregates.FileAgg
{
    public static class FileSpecifications
    {
        public static Specification<File> NonTempFiles()
        {
            return new DirectSpecification<File>(f => f.IsTempFile == false);
        }
    }
}

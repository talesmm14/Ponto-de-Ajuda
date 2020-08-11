using System;
using System.Threading.Tasks;
using Abp.TestBase;
using PontodeAjuda.EntityFrameworkCore;
using PontodeAjuda.Tests.TestDatas;

namespace PontodeAjuda.Tests
{
    public class PontodeAjudaTestBase : AbpIntegratedTestBase<PontodeAjudaTestModule>
    {
        public PontodeAjudaTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<PontodeAjudaDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<PontodeAjudaDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<PontodeAjudaDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<PontodeAjudaDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<PontodeAjudaDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<PontodeAjudaDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<PontodeAjudaDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<PontodeAjudaDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}

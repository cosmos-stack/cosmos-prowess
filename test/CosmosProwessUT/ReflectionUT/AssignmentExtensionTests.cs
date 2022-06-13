using Cosmos.Reflection;
using Cosmos.Reflection.Assignment;
using Shouldly;
using Xunit;

namespace CosmosProwessUT.ReflectionUT
{
    [Trait("ReflectionUT", "AssignmentExtension")]
    public class AssignmentExtensionTests
    {
        [Fact]
        public void ValueGettingTest()
        {
            var model = new RefTestModel() { Name = "Alex" };
            var val = model.GetValue("Name");
            val.ShouldNotBeNull();
            val.ShouldBeOfType<string>();
            ((string)val).ShouldBe("Alex");
        }

        [Fact]
        public void ValueSettingTest()
        {
            var model = new RefTestModel() { Name = "Alex" };
            model.SetValue("Name", "Lewis");
            model.Name.ShouldBe("Lewis");
        }

        [Fact]
        public void ValueFuncGettingTest()
        {
            var model = new RefTestModel() { Name = "Alex" };
            var func = model.GetValueGetter("Name");
            func.ShouldNotBeNull();

            var val = func(model);
            val.ShouldNotBeNull();
            val.ShouldBeOfType<string>();
            ((string)val).ShouldBe("Alex");
        }

        [Fact]
        public void ValueFuncSettingTest()
        {
            var model = new RefTestModel() { Name = "Alex" };
            var func = model.GetValueSetter("Name");
            func.ShouldNotBeNull();

            func(model, "Lewis");
            model.Name.ShouldBe("Lewis");
        }

        [Fact]
        public void PropertyValueFuncGettingTest()
        {
            var model = new RefTestModel() { Name = "Alex" };
            var property = model.GetProperty("Name");
            var func = property.GetValueGetter<RefTestModel>();
            func.ShouldNotBeNull();

            var val = func(model);
            val.ShouldNotBeNull();
            val.ShouldBeOfType<string>();
            ((string)val).ShouldBe("Alex");
        }

        [Fact]
        public void PropertyValueFuncSettingTest()
        {
            var model = new RefTestModel() { Name = "Alex" };
            var property = model.GetProperty("Name");
            var func = property.GetValueSetter<RefTestModel>();
            func.ShouldNotBeNull();
        
            func(model, "Lewis");
            model.Name.ShouldBe("Lewis");
        }
    }
}
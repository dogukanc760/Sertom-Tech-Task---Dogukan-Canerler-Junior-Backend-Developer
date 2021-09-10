using Business.Abstract;

using Entities.Concrete;

using System;

using Xunit;

namespace TestProject
{
    public class ClinicTest
    {
        IClinicsService _clinicService;
        public ClinicTest(IClinicsService clinicsService)
        {
            _clinicService = clinicsService;
        }
        [Fact]
        public void Add_Clinic_WhenClinicIsNull()
        {
            var result = _clinicService.Add(null);
            Assert.NotNull(result.Message);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "New Fully Clinic Data";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Delete_Clinic_WhenClinicIsNull()
        {
            var result = _clinicService.Delete(null);
            Assert.NotNull(result.Message);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "New Fully Clinic Data";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Update_Clinic_WhenClinicIsNull()
        {
            var result = _clinicService.Update(null);
            Assert.NotNull(result.Message);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "New Fully Clinic Data";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Get_Clinic_WhenNonParameter()
        {
            var result = _clinicService.GetList();
            Assert.NotNull(result.Message);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "New Fully Clinic Data";
            Assert.Equal(expected, actual);
        }
        [Theory, InlineData(new object[] { 1, "Name" })]
        public void Add_Clinic_WithAllParameter(int Id, string Name)
        {
            Clinics clinics = new Clinics { Id = Id, Name = Name };
            var result = _clinicService.Add(clinics);
            Assert.NotNull(result.Message);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "New Fully Clinic Data";
            Assert.Equal(expected, actual);
        }

        [Theory, InlineData(new object[] { "Name" })]
        public void Add_Clinic_WithRequiredParameter(string Name)
        {
            Clinics clinics = new Clinics { Name = Name };
            var result = _clinicService.Add(clinics);
            Assert.NotNull(result.Message);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "New Fully Clinic Data";
            Assert.Equal(expected, actual);
        }

        [Theory, InlineData(new object[] { 1, "Name" })]
        public void Update_Clinic_WithAllParameter(int Id, string Name)
        {
            Clinics clinics = new Clinics { Id = Id, Name = Name };
            var result = _clinicService.Update(clinics);
            Assert.NotNull(result.Message);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "New Fully Clinic Data";
            Assert.Equal(expected, actual);
        }

        [Theory, InlineData(new object[] { "Name" })]
        public void Update_Clinic_WithNotExistParameter(string Name)
        {
            Clinics clinics = new Clinics { Name = Name };
            var result = _clinicService.Update(clinics);
            Assert.NotNull(result.Message);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "New Fully Clinic Data";
            Assert.Equal(expected, actual);
        }

        [Theory, InlineData(new object[] {1})]
        public void Get_Clinic_WithParamater(int id)
        {
            var result = _clinicService.GetById(id);
            Assert.NotNull(result.Message);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "Success";
            Assert.Equal(expected, actual);

        }

    }
}

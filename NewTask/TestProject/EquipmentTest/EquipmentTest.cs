using Business.Abstract;

using Entities.Concrete;

using System;

using Xunit;

namespace TestProject
{
    public class EquipmentTest
    {
        IEquipmentService _equipmentService;
        public EquipmentTest(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }
        [Fact]
        public void Add_Equipment_WhenClinicIsNull()
        {
            var result = _equipmentService.Add(null);
            Assert.NotNull(result.Message);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "New Fully Clinic Data";
            Assert.Equal(expected, actual);
        }

        [Theory, InlineData(new object[] {1,"Isim","", 1, 5, 15})]
        public void Add_Equipment_WithParamaters(int ClinicId, string Name, DateTime AvialabilityDate, int Count, decimal UnitPrice, decimal UsingRate)
        {
            Equipment equipment = new Equipment { 
            AvialabilityDate = AvialabilityDate,
            ClinicId = ClinicId,
            Name = Name,
            Count = Count,
            UnitPrice = UnitPrice,
            UsingRate = UsingRate
            };
            var result = _equipmentService.Add(equipment);
            Assert.NotNull(result.Message);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "New Fully Clinic Data";
            Assert.Equal(expected, actual);
        }

        [Theory, InlineData(new object[] {1 ,1, "Isim", "", 1, 5, 15 })]
        public void Update_Equipment_WithParamaters(int Id,int ClinicId, string Name, DateTime AvialabilityDate, int Count, decimal UnitPrice, decimal UsingRate)
        {
            Equipment equipment = new Equipment
            {
                Id = Id,
                AvialabilityDate = AvialabilityDate,
                ClinicId = ClinicId,
                Name = Name,
                Count = Count,
                UnitPrice = UnitPrice,
                UsingRate = UsingRate
            };
            var result = _equipmentService.Add(equipment);
            Assert.NotNull(result.Message);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "New Fully Clinic Data";
            Assert.Equal(expected, actual);
        }
        [Theory, InlineData(new object[] { 1, 1, "Isim", "", 1, 5, 15 })]
        public void Delete_Equipment_WithParamaters(int Id, int ClinicId, string Name, DateTime AvialabilityDate, int Count, decimal UnitPrice, decimal UsingRate)
        {
            Equipment equipment = new Equipment
            {
                Id = Id,
                AvialabilityDate = AvialabilityDate,
                ClinicId = ClinicId,
                Name = Name,
                Count = Count,
                UnitPrice = UnitPrice,
                UsingRate = UsingRate
            };
            var result = _equipmentService.Delete(equipment);
            Assert.NotNull(result.Message);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "New Fully Clinic Data";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Delete_Equipment_WhenClinicIsNull()
        {
            var result = _equipmentService.Delete(null);
            Assert.NotNull(result.Message);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "New Fully Clinic Data";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Update_Equipment_WhenClinicIsNull()
        {
            var result = _equipmentService.Update(null);
            Assert.NotNull(result.Message);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "New Fully Clinic Data";
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Get_Equipment_WhenNonParameter()
        {
            var result = _equipmentService.GetList();
            Assert.NotNull(result.Message);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "New Fully Clinic Data";
            Assert.Equal(expected, actual);
        }

        [Theory, InlineData(new object[] {1})]
        public void Get_Equipment_WithParamater(int id)
        {
            var result = _equipmentService.GetById(id);
            Assert.NotNull(result.Message);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "Success";
            Assert.Equal(expected, actual);

        }


        [Theory, InlineData(new object[] { 1 })]
        public void Get_EquipmentDetail_WithParamater(int id)
        {
            var result = _equipmentService.GetListByClinicDetail(id);
            Assert.NotNull(result.Message);
            var exception = Assert.IsType<ArgumentNullException>(result);
            var actual = exception.ParamName;
            const string expected = "Success";
            Assert.Equal(expected, actual);

        }
    }
}

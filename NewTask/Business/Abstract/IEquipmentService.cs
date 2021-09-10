using Core.Entities.ViewModel;
using Core.Utilities.Results;
using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEquipmentService
    {
        IDataResult<Equipment> GetById(int equipmentId);
        IDataResult<List<Equipment>> GetList();
        IDataResult<List<Equipment>> GetListByOrd(bool ordType);
        IDataResult<List<Equipment>> GetListByPage(int takeCount, int pageCount);
        IDataResult<List<Equipment>> GetListByClinic(int clinicId);
        IDataResult<List<EquipmentByClinicViewModel>> GetListByClinicDetail(int clinicId);
        IDataResult<List<Equipment>> GetListByBuyDate(DateTime buyDate);
        IDataResult<List<Equipment>> GetListByBetweenDates(DateTime startDate, DateTime finishDate);

        IResult Add(Equipment equipment);
        IResult Delete(Equipment equipment);
        IResult Update(Equipment equipment);
    }
}

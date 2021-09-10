using Core.Utilities.Results;
using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IClinicsService
    {

        IDataResult<Clinics> GetById(int clinicId);
        IDataResult<List<Clinics>> GetList();
        
        IResult Add(Clinics clinics);
        IResult Delete(Clinics clinics);
        IResult Update(Clinics clinics);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendApp.Context;
using BackendApp.Repositories;

namespace BackendApp.UnitOfWork
{
    public class UnitOfWork
    {
        private AppDbContext _context;

        private DeviceTypeRepository _deviceTypeRepository;
        private DeviceRepository _deviceRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public DeviceTypeRepository DeviceTypeRepo
        {
            get
            {
                if (_deviceTypeRepository == null)
                {
                    _deviceTypeRepository = new DeviceTypeRepository(_context);
                }
                return _deviceTypeRepository;
            }
        }

        public DeviceRepository DeviceRepo
        {
            get
            {
                if (_deviceRepository == null)
                {
                    _deviceRepository = new DeviceRepository(_context);
                }
                return _deviceRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TheNextCar.Model;

namespace TheNextCar.Controller
{
    class DoorController
    {
        private Door door;
        private OnDoorChanged OnDoorChanged;

        public DoorController(OnDoorChanged onDoorChanged)
        {
            this.door = new Door();
            this.OnDoorChanged = onDoorChanged;
        }

        public void close()
        {
            this.door.close();
            this.OnDoorChanged.doorStatusChanged("CLOSED", "door is closed");
        }

        public void open()
        { 
            this.door.open();
            this.OnDoorChanged.doorStatusChanged("OPENED", "door is opened");
        }

        public void activateLock()
        {
            if(this.door.isClosed())
            {
                this.door.activateLock();
                OnDoorChanged.doorSecurityChanged("LOCKED", "door is locked");
            }
            else
            {
                unlock();
            }
        }

        public void unlock()
        {
            this.door.unlock();
            OnDoorChanged.doorSecurityChanged("UNLOCKED", "door is unlocked");
        }

        public bool isClose()
        {
            return this.door.isClosed();
        }

        public bool isLocked()
        {
            return this.door.isLocked();
        }
    }
    interface OnDoorChanged
    {
        void doorSecurityChanged(string vale, string message);
        void doorStatusChanged(string vale, string message);
    }
}

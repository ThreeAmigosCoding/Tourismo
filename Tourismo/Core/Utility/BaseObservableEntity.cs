using System;

namespace Tourismo.Core.Utility
{
    public class BaseObservableEntity : ObservableEntity, IBaseEntity
    {

        private Guid _id;
        public Guid Id { get => _id; set => OnPropertyChanged(ref _id, value); }

        private DateTime _createdAt = DateTime.Now;
        public DateTime CreatedAt { get => _createdAt; set => OnPropertyChanged(ref _createdAt, value); }

        private bool _isActive = true;
        public bool IsActive { get => _isActive; set => OnPropertyChanged(ref _isActive, value); }

        public BaseObservableEntity(BaseObservableEntity baseObservableEntity)
        {
            _id = baseObservableEntity.Id;
            _createdAt = baseObservableEntity._createdAt;
            _isActive = baseObservableEntity.IsActive;
        }
        public BaseObservableEntity() { }

    }
}

import { useState } from 'react';

function Services() {
  const [services, setServices] = useState([
    { id: 1, name: 'Plan Básico', price: 50000, isSubscription: true, description: 'Acceso al gimnasio básico con equipos de cardio y pesas', state: true },
    { id: 2, name: 'Plan Premium', price: 80000, isSubscription: true, description: 'Acceso completo + clases grupales + entrenador personal', state: true },
    { id: 3, name: 'Clase de Yoga', price: 15000, isSubscription: false, description: 'Clase individual de yoga de 1 hora', state: true },
    { id: 4, name: 'Plan Estudiante', price: 35000, isSubscription: true, description: 'Plan especial para estudiantes con horario limitado', state: true },
  ]);

  const [showForm, setShowForm] = useState(false);
  const [editingService, setEditingService] = useState(null);
  const [formData, setFormData] = useState({
    name: '',
    price: '',
    isSubscription: true,
    description: '',
    state: true
  });

  const handleSubmit = (e) => {
    e.preventDefault();
    if (editingService) {
      setServices(services.map(s => s.id === editingService.id ? { ...formData, id: editingService.id } : s));
    } else {
      setServices([...services, { ...formData, id: services.length + 1 }]);
    }
    resetForm();
  };

  const handleEdit = (service) => {
    setEditingService(service);
    setFormData({
      name: service.name,
      price: service.price,
      isSubscription: service.isSubscription,
      description: service.description,
      state: service.state
    });
    setShowForm(true);
  };

  const handleDelete = (id) => {
    if (confirm('¿Está seguro de eliminar este servicio?')) {
      setServices(services.filter(s => s.id !== id));
    }
  };

  const resetForm = () => {
    setFormData({ name: '', price: '', isSubscription: true, description: '', state: true });
    setEditingService(null);
    setShowForm(false);
  };

  return (
    <div>
      <div className="page-header">
        <h1>Gestión de Servicios</h1>
        <button className="btn-primary" onClick={() => setShowForm(!showForm)}>
          {showForm ? 'Cancelar' : '+ Nuevo Servicio'}
        </button>
      </div>

      {showForm && (
        <div className="form-container">
          <h2>{editingService ? 'Editar Servicio' : 'Nuevo Servicio'}</h2>
          <form onSubmit={handleSubmit}>
            <div className="form-group">
              <label>Nombre del Servicio</label>
              <input
                type="text"
                value={formData.name}
                onChange={(e) => setFormData({ ...formData, name: e.target.value })}
                required
              />
            </div>
            <div className="form-group">
              <label>Precio</label>
              <input
                type="number"
                value={formData.price}
                onChange={(e) => setFormData({ ...formData, price: e.target.value })}
                required
              />
            </div>
            <div className="form-group">
              <label>Tipo de Servicio</label>
              <select
                value={formData.isSubscription}
                onChange={(e) => setFormData({ ...formData, isSubscription: e.target.value === 'true' })}
                required
              >
                <option value="true">Suscripción</option>
                <option value="false">Pago Único</option>
              </select>
            </div>
            <div className="form-group">
              <label>Descripción</label>
              <textarea
                value={formData.description}
                onChange={(e) => setFormData({ ...formData, description: e.target.value })}
                rows="4"
                required
              />
            </div>
            <div className="form-group">
              <label>Estado</label>
              <select
                value={formData.state}
                onChange={(e) => setFormData({ ...formData, state: e.target.value === 'true' })}
              >
                <option value="true">Activo</option>
                <option value="false">Inactivo</option>
              </select>
            </div>
            <div className="form-actions">
              <button type="submit" className="btn-success">
                {editingService ? 'Actualizar' : 'Guardar'}
              </button>
              <button type="button" className="btn-secondary" onClick={resetForm}>
                Cancelar
              </button>
            </div>
          </form>
        </div>
      )}

      <table>
        <thead>
          <tr>
            <th>Nombre</th>
            <th>Precio</th>
            <th>Tipo</th>
            <th>Descripción</th>
            <th>Estado</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {services.map(service => (
            <tr key={service.id}>
              <td>{service.name}</td>
              <td>${service.price.toLocaleString()}</td>
              <td>
                <span className={`badge ${service.isSubscription ? 'badge-success' : 'badge-warning'}`}>
                  {service.isSubscription ? 'Suscripción' : 'Pago Único'}
                </span>
              </td>
              <td>{service.description}</td>
              <td>
                <span className={`badge ${service.state ? 'badge-success' : 'badge-danger'}`}>
                  {service.state ? 'Activo' : 'Inactivo'}
                </span>
              </td>
              <td>
                <div className="action-buttons">
                  <button className="btn-warning" onClick={() => handleEdit(service)}>Editar</button>
                  <button className="btn-danger" onClick={() => handleDelete(service.id)}>Eliminar</button>
                </div>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default Services;

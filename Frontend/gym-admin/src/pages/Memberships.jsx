import { useState } from 'react';

function Memberships() {
  const [memberships, setMemberships] = useState([
    { id: 1, userId: 1, userName: 'Juan Pérez', type: 'monthly', startDate: '2024-01-15', endDate: '2024-02-15', serviceId: 1, serviceName: 'Plan Básico', state: true },
    { id: 2, userId: 2, userName: 'María García', type: 'monthly', startDate: '2024-02-20', endDate: '2024-03-20', serviceId: 2, serviceName: 'Plan Premium', state: true },
    { id: 3, userId: 3, userName: 'Carlos López', type: 'biweekly', startDate: '2024-03-10', endDate: '2024-03-25', serviceId: 1, serviceName: 'Plan Básico', state: false },
  ]);

  const [showForm, setShowForm] = useState(false);
  const [editingMembership, setEditingMembership] = useState(null);
  const [formData, setFormData] = useState({
    userId: '',
    userName: '',
    type: 'monthly',
    startDate: '',
    endDate: '',
    serviceId: '',
    serviceName: '',
    state: true
  });

  const membershipTypes = ['monthly', 'biweekly', 'daily', 'trial'];

  const handleSubmit = (e) => {
    e.preventDefault();
    if (editingMembership) {
      setMemberships(memberships.map(m => m.id === editingMembership.id ? { ...formData, id: editingMembership.id } : m));
    } else {
      setMemberships([...memberships, { ...formData, id: memberships.length + 1 }]);
    }
    resetForm();
  };

  const handleEdit = (membership) => {
    setEditingMembership(membership);
    setFormData({
      userId: membership.userId,
      userName: membership.userName,
      type: membership.type,
      startDate: membership.startDate,
      endDate: membership.endDate,
      serviceId: membership.serviceId,
      serviceName: membership.serviceName,
      state: membership.state
    });
    setShowForm(true);
  };

  const handleDelete = (id) => {
    if (confirm('¿Está seguro de eliminar esta membresía?')) {
      setMemberships(memberships.filter(m => m.id !== id));
    }
  };

  const resetForm = () => {
    setFormData({ userId: '', userName: '', type: 'monthly', startDate: '', endDate: '', serviceId: '', serviceName: '', state: true });
    setEditingMembership(null);
    setShowForm(false);
  };

  return (
    <div>
      <div className="page-header">
        <h1>Gestión de Membresías</h1>
        <button className="btn-primary" onClick={() => setShowForm(!showForm)}>
          {showForm ? 'Cancelar' : '+ Nueva Membresía'}
        </button>
      </div>

      {showForm && (
        <div className="form-container">
          <h2>{editingMembership ? 'Editar Membresía' : 'Nueva Membresía'}</h2>
          <form onSubmit={handleSubmit}>
            <div className="form-group">
              <label>ID Usuario</label>
              <input
                type="number"
                value={formData.userId}
                onChange={(e) => setFormData({ ...formData, userId: e.target.value })}
                required
              />
            </div>
            <div className="form-group">
              <label>Nombre Usuario</label>
              <input
                type="text"
                value={formData.userName}
                onChange={(e) => setFormData({ ...formData, userName: e.target.value })}
                required
              />
            </div>
            <div className="form-group">
              <label>Tipo de Membresía</label>
              <select
                value={formData.type}
                onChange={(e) => setFormData({ ...formData, type: e.target.value })}
                required
              >
                {membershipTypes.map(type => (
                  <option key={type} value={type}>{type}</option>
                ))}
              </select>
            </div>
            <div className="form-group">
              <label>Fecha Inicio</label>
              <input
                type="date"
                value={formData.startDate}
                onChange={(e) => setFormData({ ...formData, startDate: e.target.value })}
                required
              />
            </div>
            <div className="form-group">
              <label>Fecha Fin</label>
              <input
                type="date"
                value={formData.endDate}
                onChange={(e) => setFormData({ ...formData, endDate: e.target.value })}
                required
              />
            </div>
            <div className="form-group">
              <label>ID Servicio</label>
              <input
                type="number"
                value={formData.serviceId}
                onChange={(e) => setFormData({ ...formData, serviceId: e.target.value })}
                required
              />
            </div>
            <div className="form-group">
              <label>Nombre Servicio</label>
              <input
                type="text"
                value={formData.serviceName}
                onChange={(e) => setFormData({ ...formData, serviceName: e.target.value })}
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
                {editingMembership ? 'Actualizar' : 'Guardar'}
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
            <th>Usuario</th>
            <th>Tipo</th>
            <th>Servicio</th>
            <th>Fecha Inicio</th>
            <th>Fecha Fin</th>
            <th>Estado</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {memberships.map(membership => (
            <tr key={membership.id}>
              <td>{membership.userName}</td>
              <td><span className="badge badge-info">{membership.type}</span></td>
              <td>{membership.serviceName}</td>
              <td>{membership.startDate}</td>
              <td>{membership.endDate}</td>
              <td>
                <span className={`badge ${membership.state ? 'badge-success' : 'badge-danger'}`}>
                  {membership.state ? 'Activa' : 'Inactiva'}
                </span>
              </td>
              <td>
                <div className="action-buttons">
                  <button className="btn-warning" onClick={() => handleEdit(membership)}>Editar</button>
                  <button className="btn-danger" onClick={() => handleDelete(membership.id)}>Eliminar</button>
                </div>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default Memberships;

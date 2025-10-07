import { useState } from 'react';

function Users() {
  const [users, setUsers] = useState([
    { id: 1, firstName: 'Juan', lastName: 'Pérez', identification: '1234567890', phone: '3001234567', email: 'juan@email.com', registrationDate: '2024-01-15', state: true },
    { id: 2, firstName: 'María', lastName: 'García', identification: '0987654321', phone: '3109876543', email: 'maria@email.com', registrationDate: '2024-02-20', state: true },
    { id: 3, firstName: 'Carlos', lastName: 'López', identification: '1122334455', phone: '3201122334', email: 'carlos@email.com', registrationDate: '2024-03-10', state: false },
  ]);

  const [showForm, setShowForm] = useState(false);
  const [editingUser, setEditingUser] = useState(null);
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    identification: '',
    phone: '',
    email: '',
    state: true
  });

  const handleSubmit = (e) => {
    e.preventDefault();
    if (editingUser) {
      setUsers(users.map(u => u.id === editingUser.id ? { ...formData, id: editingUser.id, registrationDate: editingUser.registrationDate } : u));
    } else {
      setUsers([...users, { ...formData, id: users.length + 1, registrationDate: new Date().toISOString().split('T')[0] }]);
    }
    resetForm();
  };

  const handleEdit = (user) => {
    setEditingUser(user);
    setFormData({
      firstName: user.firstName,
      lastName: user.lastName,
      identification: user.identification,
      phone: user.phone,
      email: user.email,
      state: user.state
    });
    setShowForm(true);
  };

  const handleDelete = (id) => {
    if (confirm('¿Está seguro de eliminar este usuario?')) {
      setUsers(users.filter(u => u.id !== id));
    }
  };

  const resetForm = () => {
    setFormData({ firstName: '', lastName: '', identification: '', phone: '', email: '', state: true });
    setEditingUser(null);
    setShowForm(false);
  };

  return (
    <div>
      <div className="page-header">
        <h1>Gestión de Usuarios</h1>
        <button className="btn-primary" onClick={() => setShowForm(!showForm)}>
          {showForm ? 'Cancelar' : '+ Nuevo Usuario'}
        </button>
      </div>

      {showForm && (
        <div className="form-container">
          <h2>{editingUser ? 'Editar Usuario' : 'Nuevo Usuario'}</h2>
          <form onSubmit={handleSubmit}>
            <div className="form-group">
              <label>Nombre</label>
              <input
                type="text"
                value={formData.firstName}
                onChange={(e) => setFormData({ ...formData, firstName: e.target.value })}
                required
              />
            </div>
            <div className="form-group">
              <label>Apellido</label>
              <input
                type="text"
                value={formData.lastName}
                onChange={(e) => setFormData({ ...formData, lastName: e.target.value })}
                required
              />
            </div>
            <div className="form-group">
              <label>Identificación</label>
              <input
                type="text"
                value={formData.identification}
                onChange={(e) => setFormData({ ...formData, identification: e.target.value })}
                required
              />
            </div>
            <div className="form-group">
              <label>Teléfono</label>
              <input
                type="tel"
                value={formData.phone}
                onChange={(e) => setFormData({ ...formData, phone: e.target.value })}
                required
              />
            </div>
            <div className="form-group">
              <label>Email</label>
              <input
                type="email"
                value={formData.email}
                onChange={(e) => setFormData({ ...formData, email: e.target.value })}
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
                {editingUser ? 'Actualizar' : 'Guardar'}
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
            <th>Apellido</th>
            <th>Identificación</th>
            <th>Teléfono</th>
            <th>Email</th>
            <th>Fecha Registro</th>
            <th>Estado</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {users.map(user => (
            <tr key={user.id}>
              <td>{user.firstName}</td>
              <td>{user.lastName}</td>
              <td>{user.identification}</td>
              <td>{user.phone}</td>
              <td>{user.email}</td>
              <td>{user.registrationDate}</td>
              <td>
                <span className={`badge ${user.state ? 'badge-success' : 'badge-danger'}`}>
                  {user.state ? 'Activo' : 'Inactivo'}
                </span>
              </td>
              <td>
                <div className="action-buttons">
                  <button className="btn-warning" onClick={() => handleEdit(user)}>Editar</button>
                  <button className="btn-danger" onClick={() => handleDelete(user.id)}>Eliminar</button>
                </div>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default Users;

import { useState } from 'react';
import { Check, X, DollarSign, Calendar, User } from 'lucide-react';

function Payments() {
  const [users, setUsers] = useState([
    {
      id: 1,
      name: 'Juan Pérez',
      email: 'juan@email.com',
      membershipType: 'Mensual',
      amount: 45000,
      dueDate: '2024-10-15',
      paid: true,
      paidDate: '2024-10-14'
    },
    {
      id: 2,
      name: 'María García',
      email: 'maria@email.com',
      membershipType: 'Mensual',
      amount: 45000,
      dueDate: '2024-10-20',
      paid: false,
      paidDate: null
    },
    {
      id: 3,
      name: 'Carlos López',
      email: 'carlos@email.com',
      membershipType: 'Quincenal',
      amount: 25000,
      dueDate: '2024-10-10',
      paid: false,
      paidDate: null
    },
  ]);

  const [filter, setFilter] = useState('all'); // all, paid, unpaid

  const handleTogglePayment = (userId) => {
    setUsers(users.map(user => {
      if (user.id === userId) {
        return {
          ...user,
          paid: !user.paid,
          paidDate: !user.paid ? new Date().toISOString().split('T')[0] : null
        };
      }
      return user;
    }));
  };

  const filteredUsers = users.filter(user => {
    if (filter === 'paid') return user.paid;
    if (filter === 'unpaid') return !user.paid;
    return true;
  });

  const totalPaid = users.filter(u => u.paid).reduce((sum, u) => sum + u.amount, 0);
  const totalPending = users.filter(u => !u.paid).reduce((sum, u) => sum + u.amount, 0);

  return (
    <div>
      <div className="page-header">
        <div>
          <h1>Gestión de Pagos</h1>
          <p style={{ color: '#6b7280', marginTop: '0.5rem' }}>
            Control de pagos mensuales de membresías
          </p>
        </div>
      </div>

      {/* Tarjetas de resumen */}
      <div className="stats-container" style={{ marginBottom: '2rem' }}>
        <div className="stat-card">
          <div className="stat-icon" style={{ backgroundColor: '#10b981' }}>
            <DollarSign size={28} />
          </div>
          <div className="stat-info">
            <h3>Total Cobrado</h3>
            <div className="stat-value">${totalPaid.toLocaleString()}</div>
          </div>
        </div>
        <div className="stat-card">
          <div className="stat-icon" style={{ backgroundColor: '#f59e0b' }}>
            <Calendar size={28} />
          </div>
          <div className="stat-info">
            <h3>Total Pendiente</h3>
            <div className="stat-value">${totalPending.toLocaleString()}</div>
          </div>
        </div>
        <div className="stat-card">
          <div className="stat-icon" style={{ backgroundColor: '#6366f1' }}>
            <User size={28} />
          </div>
          <div className="stat-info">
            <h3>Usuarios al Día</h3>
            <div className="stat-value">{users.filter(u => u.paid).length}/{users.length}</div>
          </div>
        </div>
      </div>

      {/* Filtros */}
      <div className="form-container" style={{ marginBottom: '2rem', padding: '1rem' }}>
        <div style={{ display: 'flex', gap: '1rem', alignItems: 'center' }}>
          <span style={{ fontWeight: '600', color: '#374151' }}>Filtrar:</span>
          <button
            className={filter === 'all' ? 'btn-primary' : 'btn-secondary'}
            onClick={() => setFilter('all')}
            style={{ padding: '0.5rem 1rem' }}
          >
            Todos ({users.length})
          </button>
          <button
            className={filter === 'paid' ? 'btn-success' : 'btn-secondary'}
            onClick={() => setFilter('paid')}
            style={{ padding: '0.5rem 1rem' }}
          >
            Pagados ({users.filter(u => u.paid).length})
          </button>
          <button
            className={filter === 'unpaid' ? 'btn-warning' : 'btn-secondary'}
            onClick={() => setFilter('unpaid')}
            style={{ padding: '0.5rem 1rem' }}
          >
            Pendientes ({users.filter(u => !u.paid).length})
          </button>
        </div>
      </div>

      {/* Tabla de usuarios */}
      <table>
        <thead>
          <tr>
            <th>Usuario</th>
            <th>Email</th>
            <th>Tipo Membresía</th>
            <th>Monto</th>
            <th>Fecha Vencimiento</th>
            <th>Fecha de Pago</th>
            <th>Estado</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {filteredUsers.map(user => (
            <tr key={user.id}>
              <td style={{ fontWeight: '600' }}>{user.name}</td>
              <td>{user.email}</td>
              <td>
                <span className="badge badge-info">{user.membershipType}</span>
              </td>
              <td style={{ fontWeight: '600', color: '#10b981' }}>
                ${user.amount.toLocaleString()}
              </td>
              <td>{user.dueDate}</td>
              <td>{user.paidDate || '-'}</td>
              <td>
                <span className={`badge ${user.paid ? 'badge-success' : 'badge-warning'}`}>
                  {user.paid ? 'Pagado' : 'Pendiente'}
                </span>
              </td>
              <td>
                <button
                  className={user.paid ? 'btn-danger' : 'btn-success'}
                  onClick={() => handleTogglePayment(user.id)}
                  style={{
                    display: 'flex',
                    alignItems: 'center',
                    gap: '0.5rem',
                    padding: '0.5rem 1rem'
                  }}
                >
                  {user.paid ? (
                    <>
                      <X size={18} />
                      Marcar No Pagado
                    </>
                  ) : (
                    <>
                      <Check size={18} />
                      Marcar Pagado
                    </>
                  )}
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      {filteredUsers.length === 0 && (
        <div style={{
          textAlign: 'center',
          padding: '3rem',
          color: '#6b7280',
          background: 'white',
          borderRadius: '12px',
          marginTop: '1rem'
        }}>
          No hay usuarios en esta categoría
        </div>
      )}
    </div>
  );
}

export default Payments;

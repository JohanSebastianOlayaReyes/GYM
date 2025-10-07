import { useState } from 'react';
import { Check, UserCheck, Clock, Users } from 'lucide-react';

function Attendance() {
  const today = new Date().toISOString().split('T')[0];
  const currentTime = new Date().toLocaleTimeString('es-CO', { hour: '2-digit', minute: '2-digit' });

  const [users, setUsers] = useState([
    {
      id: 1,
      name: 'Juan Pérez',
      email: 'juan@email.com',
      membershipType: 'Mensual',
      attended: false,
      attendanceTime: null
    },
    {
      id: 2,
      name: 'María García',
      email: 'maria@email.com',
      membershipType: 'Mensual',
      attended: true,
      attendanceTime: '08:30'
    },
    {
      id: 3,
      name: 'Carlos López',
      email: 'carlos@email.com',
      membershipType: 'Quincenal',
      attended: false,
      attendanceTime: null
    },
    {
      id: 4,
      name: 'Ana Martínez',
      email: 'ana@email.com',
      membershipType: 'Mensual',
      attended: true,
      attendanceTime: '09:15'
    },
  ]);

  const [searchTerm, setSearchTerm] = useState('');

  const handleMarkAttendance = (userId) => {
    setUsers(users.map(user => {
      if (user.id === userId && !user.attended) {
        return {
          ...user,
          attended: true,
          attendanceTime: currentTime
        };
      }
      return user;
    }));
  };

  const filteredUsers = users.filter(user =>
    user.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
    user.email.toLowerCase().includes(searchTerm.toLowerCase())
  );

  const attendedCount = users.filter(u => u.attended).length;
  const notAttendedCount = users.length - attendedCount;

  return (
    <div>
      <div className="page-header">
        <div>
          <h1>Registro de Asistencia</h1>
          <p style={{ color: '#6b7280', marginTop: '0.5rem' }}>
            Fecha: {new Date().toLocaleDateString('es-CO', {
              weekday: 'long',
              year: 'numeric',
              month: 'long',
              day: 'numeric'
            })}
          </p>
        </div>
      </div>

      {/* Tarjetas de resumen */}
      <div className="stats-container" style={{ marginBottom: '2rem' }}>
        <div className="stat-card">
          <div className="stat-icon" style={{ backgroundColor: '#10b981' }}>
            <UserCheck size={28} />
          </div>
          <div className="stat-info">
            <h3>Asistieron Hoy</h3>
            <div className="stat-value">{attendedCount}</div>
          </div>
        </div>
        <div className="stat-card">
          <div className="stat-icon" style={{ backgroundColor: '#f59e0b' }}>
            <Users size={28} />
          </div>
          <div className="stat-info">
            <h3>Pendientes</h3>
            <div className="stat-value">{notAttendedCount}</div>
          </div>
        </div>
        <div className="stat-card">
          <div className="stat-icon" style={{ backgroundColor: '#6366f1' }}>
            <Clock size={28} />
          </div>
          <div className="stat-info">
            <h3>Hora Actual</h3>
            <div className="stat-value" style={{ fontSize: '1.5rem' }}>{currentTime}</div>
          </div>
        </div>
      </div>

      {/* Buscador */}
      <div className="form-container" style={{ marginBottom: '2rem' }}>
        <div className="form-group" style={{ marginBottom: 0 }}>
          <label>Buscar Usuario</label>
          <input
            type="text"
            placeholder="Buscar por nombre o email..."
            value={searchTerm}
            onChange={(e) => setSearchTerm(e.target.value)}
            style={{ fontSize: '1rem' }}
          />
        </div>
      </div>

      {/* Tabla de usuarios */}
      <table>
        <thead>
          <tr>
            <th>Usuario</th>
            <th>Email</th>
            <th>Tipo Membresía</th>
            <th>Hora de Entrada</th>
            <th>Estado</th>
            <th>Acción</th>
          </tr>
        </thead>
        <tbody>
          {filteredUsers.map(user => (
            <tr key={user.id} style={{ backgroundColor: user.attended ? '#f0fdf4' : 'white' }}>
              <td style={{ fontWeight: '600' }}>{user.name}</td>
              <td>{user.email}</td>
              <td>
                <span className="badge badge-info">{user.membershipType}</span>
              </td>
              <td style={{ fontWeight: '600', color: user.attended ? '#10b981' : '#6b7280' }}>
                {user.attendanceTime || '-'}
              </td>
              <td>
                <span className={`badge ${user.attended ? 'badge-success' : 'badge-warning'}`}>
                  {user.attended ? 'Asistió' : 'Pendiente'}
                </span>
              </td>
              <td>
                {user.attended ? (
                  <button
                    className="btn-secondary"
                    disabled
                    style={{
                      cursor: 'not-allowed',
                      opacity: 0.6,
                      display: 'flex',
                      alignItems: 'center',
                      gap: '0.5rem'
                    }}
                  >
                    <Check size={18} />
                    Registrado
                  </button>
                ) : (
                  <button
                    className="btn-success"
                    onClick={() => handleMarkAttendance(user.id)}
                    style={{
                      display: 'flex',
                      alignItems: 'center',
                      gap: '0.5rem',
                      padding: '0.5rem 1rem'
                    }}
                  >
                    <Check size={18} />
                    Marcar Asistencia
                  </button>
                )}
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
          No se encontraron usuarios
        </div>
      )}

      {/* Información adicional */}
      <div className="form-container" style={{ marginTop: '2rem', background: '#f0f9ff' }}>
        <h3 style={{ color: '#0369a1', marginBottom: '0.5rem' }}>📋 Información</h3>
        <p style={{ color: '#0c4a6e', margin: 0 }}>
          Este registro es para el día de hoy. Una vez marcada la asistencia, no se puede deshacer.
          Los datos se guardarán automáticamente en el historial.
        </p>
      </div>
    </div>
  );
}

export default Attendance;

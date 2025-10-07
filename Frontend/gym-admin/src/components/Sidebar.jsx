import './Sidebar.css';
import { MdDashboard, MdPeople, MdCardMembership, MdPayment, MdEventAvailable, MdFitnessCenter, MdExitToApp } from 'react-icons/md';

function Sidebar({ currentPage, setCurrentPage, admin, onLogout }) {
  const menuItems = [
    { id: 'dashboard', label: 'Dashboard', Icon: MdDashboard },
    { id: 'users', label: 'Usuarios', Icon: MdPeople },
    { id: 'memberships', label: 'Membresías', Icon: MdCardMembership },
    { id: 'payments', label: 'Pagos', Icon: MdPayment },
    { id: 'attendance', label: 'Asistencia', Icon: MdEventAvailable },
    { id: 'services', label: 'Servicios', Icon: MdFitnessCenter },
  ];

  return (
    <aside className="sidebar">
      <div className="sidebar-header">
        <MdFitnessCenter className="logo-icon" />
        <h2>Gym Admin</h2>
        {admin && <p className="gym-name">{admin.gymName}</p>}
      </div>
      <nav className="sidebar-nav">
        {menuItems.map((item) => {
          const Icon = item.Icon;
          return (
            <button
              key={item.id}
              className={`nav-item ${currentPage === item.id ? 'active' : ''}`}
              onClick={() => setCurrentPage(item.id)}
            >
              <Icon className="nav-icon" />
              <span className="nav-label">{item.label}</span>
            </button>
          );
        })}
      </nav>
      <div className="sidebar-footer">
        <div className="admin-info">
          <p className="admin-name">{admin?.name}</p>
          <p className="admin-email">{admin?.email}</p>
        </div>
        <button className="btn-logout" onClick={onLogout}>
          <MdExitToApp className="nav-icon" />
          <span>Cerrar Sesión</span>
        </button>
      </div>
    </aside>
  );
}

export default Sidebar;

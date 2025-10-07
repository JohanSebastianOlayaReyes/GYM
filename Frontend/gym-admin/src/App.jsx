import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import { useState, useEffect } from 'react';
import './App.css';
import Landing from './pages/Landing';
import Register from './pages/Register';
import Login from './pages/Login';
import Sidebar from './components/Sidebar';
import Users from './pages/Users';
import Memberships from './pages/Memberships';
import Payments from './pages/Payments';
import Attendance from './pages/Attendance';
import Services from './pages/Services';
import Dashboard from './pages/Dashboard';

function App() {
  const [currentPage, setCurrentPage] = useState('dashboard');
  const [admin, setAdmin] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    // Verificar si hay un admin en localStorage
    const storedAdmin = localStorage.getItem('admin');
    if (storedAdmin) {
      setAdmin(JSON.parse(storedAdmin));
    }
    setLoading(false);
  }, []);

  const handleLogout = () => {
    localStorage.removeItem('admin');
    setAdmin(null);
    setCurrentPage('dashboard');
  };

  const renderPage = () => {
    switch (currentPage) {
      case 'dashboard':
        return <Dashboard admin={admin} />;
      case 'users':
        return <Users />;
      case 'memberships':
        return <Memberships />;
      case 'payments':
        return <Payments />;
      case 'attendance':
        return <Attendance />;
      case 'services':
        return <Services />;
      default:
        return <Dashboard admin={admin} />;
    }
  };

  if (loading) {
    return <div className="loading-screen">Cargando...</div>;
  }

  return (
    <Router>
      <Routes>
        {/* Rutas públicas */}
        <Route path="/" element={<Landing />} />
        <Route path="/register" element={<Register />} />
        <Route path="/login" element={<Login />} />

        {/* Rutas protegidas - Dashboard */}
        <Route
          path="/dashboard"
          element={
            admin ? (
              <div className="app-container">
                <Sidebar
                  currentPage={currentPage}
                  setCurrentPage={setCurrentPage}
                  admin={admin}
                  onLogout={handleLogout}
                />
                <main className="main-content">
                  {renderPage()}
                </main>
              </div>
            ) : (
              <Navigate to="/login" replace />
            )
          }
        />

        {/* Redirección por defecto */}
        <Route path="*" element={<Navigate to="/" replace />} />
      </Routes>
    </Router>
  );
}

export default App;

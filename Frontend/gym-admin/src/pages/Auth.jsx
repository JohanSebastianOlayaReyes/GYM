import { useState } from 'react';
import './Auth.css';
import { MdEmail, MdLock, MdPerson, MdFitnessCenter, MdLogin, MdPersonAdd } from 'react-icons/md';

function Auth({ onLogin }) {
  const [isLogin, setIsLogin] = useState(true);
  const [formData, setFormData] = useState({
    name: '',
    email: '',
    gymName: '',
    password: ''
  });
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(false);

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');
    setLoading(true);

    try {
      // Simular autenticación (cuando conectes al backend, usa fetch aquí)
      if (isLogin) {
        // Login simulado
        if (formData.email && formData.password) {
          const adminData = {
            name: 'Admin',
            email: formData.email,
            gymName: 'Gym Principal',
            token: 'fake-token-123'
          };
          localStorage.setItem('admin', JSON.stringify(adminData));
          onLogin(adminData);
        } else {
          setError('Por favor ingrese email y contraseña');
        }
      } else {
        // Registro simulado
        if (formData.name && formData.email && formData.gymName && formData.password) {
          const adminData = {
            name: formData.name,
            email: formData.email,
            gymName: formData.gymName,
            token: 'fake-token-123'
          };
          localStorage.setItem('admin', JSON.stringify(adminData));
          onLogin(adminData);
        } else {
          setError('Por favor complete todos los campos');
        }
      }
    } catch (err) {
      setError('Error al procesar la solicitud');
    } finally {
      setLoading(false);
    }
  };

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    });
  };

  return (
    <div className="auth-container">
      <div className="auth-card">
        <div className="auth-header">
          <div className="auth-logo">
            <MdFitnessCenter />
          </div>
          <h1>{isLogin ? 'Bienvenido' : 'Crear Cuenta'}</h1>
          <p>Sistema de Administración de Gimnasio</p>
        </div>

        {error && <div className="auth-error">{error}</div>}

        <form onSubmit={handleSubmit} className="auth-form">
          {!isLogin && (
            <>
              <div className="form-group">
                <label>
                  <MdPerson className="label-icon" />
                  Nombre del Administrador
                </label>
                <div className="input-wrapper">
                  <MdPerson className="input-icon" />
                  <input
                    type="text"
                    name="name"
                    value={formData.name}
                    onChange={handleChange}
                    placeholder="Juan Pérez"
                    required={!isLogin}
                  />
                </div>
              </div>

              <div className="form-group">
                <label>
                  <MdFitnessCenter className="label-icon" />
                  Nombre del Gimnasio
                </label>
                <div className="input-wrapper">
                  <MdFitnessCenter className="input-icon" />
                  <input
                    type="text"
                    name="gymName"
                    value={formData.gymName}
                    onChange={handleChange}
                    placeholder="Gym Fitness Center"
                    required={!isLogin}
                  />
                </div>
              </div>
            </>
          )}

          <div className="form-group">
            <label>
              <MdEmail className="label-icon" />
              Correo Electrónico
            </label>
            <div className="input-wrapper">
              <MdEmail className="input-icon" />
              <input
                type="email"
                name="email"
                value={formData.email}
                onChange={handleChange}
                placeholder="admin@gimnasio.com"
                required
              />
            </div>
          </div>

          <div className="form-group">
            <label>
              <MdLock className="label-icon" />
              Contraseña
            </label>
            <div className="input-wrapper">
              <MdLock className="input-icon" />
              <input
                type="password"
                name="password"
                value={formData.password}
                onChange={handleChange}
                placeholder="••••••••"
                required
              />
            </div>
          </div>

          <button type="submit" className="btn-auth" disabled={loading}>
            {loading ? (
              'Procesando...'
            ) : (
              <>
                {isLogin ? <MdLogin className="btn-icon" /> : <MdPersonAdd className="btn-icon" />}
                {isLogin ? 'Iniciar Sesión' : 'Crear Cuenta'}
              </>
            )}
          </button>
        </form>

        <div className="auth-footer">
          <p>
            {isLogin ? '¿No tienes cuenta?' : '¿Ya tienes cuenta?'}
            <button
              type="button"
              className="btn-switch"
              onClick={() => {
                setIsLogin(!isLogin);
                setError('');
              }}
            >
              {isLogin ? 'Crear cuenta' : 'Iniciar sesión'}
            </button>
          </p>
        </div>
      </div>
    </div>
  );
}

export default Auth;

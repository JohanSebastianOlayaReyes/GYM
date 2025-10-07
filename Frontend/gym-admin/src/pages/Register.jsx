import { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import { User, Mail, Phone, CreditCard, Lock, Key, Eye, EyeOff } from 'lucide-react';
import './AuthMinimal.css';

function Register() {
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    name: '',
    email: '',
    password: '',
    confirmPassword: '',
    phone: '',
    plan: 'mensual'
  });
  const [showPassword, setShowPassword] = useState(false);
  const [showConfirmPassword, setShowConfirmPassword] = useState(false);
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(false);

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    });
    setError('');
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setError('');
    setLoading(true);

    try {
      const response = await fetch('http://localhost:5062/api/Admin/register', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify({
          name: formData.name,
          email: formData.email,
          password: formData.password,
          phone: formData.phone || '',
          plan: formData.plan
        }),
      });

      if (response.ok) {
        alert('Registro exitoso! Por favor inicia sesión');
        navigate('/login');
      } else {
        const errorData = await response.json();
        setError(errorData.message || 'Error al registrar usuario');
      }
    } catch (error) {
      setError('Error de conexión. Por favor intenta de nuevo.');
      console.error('Error:', error);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="auth-minimal-container">
      {/* Lado Izquierdo - Formulario */}
      <div className="auth-left">
        <div className="auth-content">
          <div className="auth-logo">
            <div className="logo-icon-circle">
              <span>GA</span>
            </div>
          </div>

          <div className="auth-header">
            <h1>Crear Cuenta</h1>
            <p>Comienza a gestionar tu gimnasio hoy</p>
          </div>

          {error && (
            <div className="auth-error">
              {error}
            </div>
          )}

          <form onSubmit={handleSubmit} className="auth-form-minimal">
            <div className="form-field">
              <label htmlFor="name">Nombre Completo</label>
              <div className="input-wrapper">
                <User size={18} className="input-icon" />
                <input
                  type="text"
                  id="name"
                  name="name"
                  value={formData.name}
                  onChange={handleChange}
                  placeholder="Juan Pérez"
                />
              </div>
            </div>

            <div className="form-field">
              <label htmlFor="email">Email</label>
              <div className="input-wrapper">
                <Mail size={18} className="input-icon" />
                <input
                  type="email"
                  id="email"
                  name="email"
                  value={formData.email}
                  onChange={handleChange}
                  placeholder="ejemplo@correo.com"
                />
              </div>
            </div>

            <div className="form-field">
              <label htmlFor="phone">Teléfono</label>
              <div className="input-wrapper">
                <Phone size={18} className="input-icon" />
                <input
                  type="tel"
                  id="phone"
                  name="phone"
                  value={formData.phone}
                  onChange={handleChange}
                  placeholder="300 123 4567"
                />
              </div>
            </div>

            <div className="form-field">
              <label htmlFor="plan">Plan</label>
              <div className="input-wrapper">
                <CreditCard size={18} className="input-icon" />
                <select
                  id="plan"
                  name="plan"
                  value={formData.plan}
                  onChange={handleChange}
                >
                  <option value="quincenal">Quincenal - $25.000</option>
                  <option value="mensual">Mensual - $45.000</option>
                  <option value="anual">Anual - $480.000</option>
                </select>
              </div>
            </div>

            <div className="form-field">
              <label htmlFor="password">Password</label>
              <div className="input-wrapper">
                <Lock size={18} className="input-icon" />
                <input
                  type={showPassword ? "text" : "password"}
                  id="password"
                  name="password"
                  value={formData.password}
                  onChange={handleChange}
                  placeholder="••••••••"
                />
                <button
                  type="button"
                  className="toggle-password"
                  onClick={() => setShowPassword(!showPassword)}
                >
                  {showPassword ? <EyeOff size={18} /> : <Eye size={18} />}
                </button>
              </div>
            </div>

            <div className="form-field">
              <label htmlFor="confirmPassword">Confirmar Password</label>
              <div className="input-wrapper">
                <Key size={18} className="input-icon" />
                <input
                  type={showConfirmPassword ? "text" : "password"}
                  id="confirmPassword"
                  name="confirmPassword"
                  value={formData.confirmPassword}
                  onChange={handleChange}
                  placeholder="••••••••"
                />
                <button
                  type="button"
                  className="toggle-password"
                  onClick={() => setShowConfirmPassword(!showConfirmPassword)}
                >
                  {showConfirmPassword ? <EyeOff size={18} /> : <Eye size={18} />}
                </button>
              </div>
            </div>

            <button type="submit" className="btn-submit" disabled={loading}>
              {loading ? 'Registrando...' : 'Crear Cuenta'}
            </button>
          </form>

          <div className="auth-footer">
            <p>¿Ya tienes una cuenta? <Link to="/login">Iniciar Sesión</Link></p>
            <Link to="/" className="back-home">← Volver al inicio</Link>
          </div>
        </div>
      </div>

      {/* Lado Derecho - Fondo Decorativo */}
      <div className="auth-right">
        <div className="decorative-circle">
          <div className="circle-icon">
            <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2">
              <path d="M12 2L2 7l10 5 10-5-10-5zM2 17l10 5 10-5M2 12l10 5 10-5"/>
            </svg>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Register;

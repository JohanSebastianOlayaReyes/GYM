import { useNavigate } from 'react-router-dom';
import { Users, CreditCard, BarChart3, ClipboardCheck, Dumbbell, Shield, Check, TrendingUp, Calendar, DollarSign } from 'lucide-react';
import './Landing.css';

function Landing() {
  const navigate = useNavigate();

  const plans = [
    {
      name: 'Plan Quincenal',
      price: '$25.000',
      period: '/ 15 días',
      features: [
        'Acceso completo al panel administrativo',
        'Gestión de hasta 50 miembros',
        'Reportes básicos de asistencia',
        'Soporte por email',
        'Actualizaciones incluidas'
      ]
    },
    {
      name: 'Plan Mensual',
      price: '$45.000',
      period: '/ mes',
      popular: true,
      features: [
        'Acceso completo al panel administrativo',
        'Gestión ilimitada de miembros',
        'Reportes detallados y estadísticas',
        'Control de pagos y membresías',
        'Gestión de servicios y clases',
        'Soporte prioritario 24/7',
        'Actualizaciones automáticas',
        'Backup diario de datos'
      ]
    },
    {
      name: 'Plan Anual',
      price: '$480.000',
      period: '/ año',
      save: 'Ahorra $60.000',
      features: [
        'Todo lo incluido en el plan mensual',
        'Múltiples sucursales (hasta 5)',
        'API para integraciones',
        'Dashboard personalizable',
        'Reportes avanzados exportables',
        'Gestor de inventario',
        'Sistema de notificaciones SMS',
        'Capacitación personalizada',
        'Soporte dedicado premium'
      ]
    }
  ];

  return (
    <div className="landing-container">
      {/* Hero Section */}
      <section className="hero-section">
        <div className="hero-content">
          <div className="company-badge">
            <Shield size={16} />
            <span>TechSoft Solutions</span>
          </div>
          <h1 className="hero-title">Soluciones de Software Empresarial</h1>
          <p className="hero-subtitle">
            Desarrollamos sistemas personalizados para potenciar tu negocio
          </p>
          <div className="hero-stats">
            <div className="stat-item">
              <strong>50+</strong>
              <span>Proyectos Entregados</span>
            </div>
            <div className="stat-item">
              <strong>100+</strong>
              <span>Clientes Satisfechos</span>
            </div>
            <div className="stat-item">
              <strong>5 años</strong>
              <span>De Experiencia</span>
            </div>
          </div>
        </div>
      </section>

      {/* About Software Section */}
      <section className="about-software">
        <div className="section-header">
          <span className="section-badge">
            <Dumbbell size={18} />
            Nuestro Producto
          </span>
          <h2>Sistema de Gestión Administrativa para Gimnasios</h2>
          <p>Panel administrativo completo para gestionar tu gimnasio de manera profesional y eficiente</p>
        </div>

        <div className="features-grid">
          <div className="feature-card">
            <div className="feature-icon">
              <Users size={32} strokeWidth={2} />
            </div>
            <h3>Gestión de Miembros</h3>
            <p>Administra la base de datos completa de tus clientes, historial de pagos, estado de membresías y más</p>
          </div>

          <div className="feature-card">
            <div className="feature-icon">
              <CreditCard size={32} strokeWidth={2} />
            </div>
            <h3>Control de Pagos</h3>
            <p>Seguimiento detallado de pagos, facturación automática, recordatorios y gestión de deudas</p>
          </div>

          <div className="feature-card">
            <div className="feature-icon">
              <BarChart3 size={32} strokeWidth={2} />
            </div>
            <h3>Reportes y Estadísticas</h3>
            <p>Análisis completo del rendimiento de tu gimnasio con gráficos, métricas y reportes exportables</p>
          </div>

          <div className="feature-card">
            <div className="feature-icon">
              <ClipboardCheck size={32} strokeWidth={2} />
            </div>
            <h3>Control de Asistencia</h3>
            <p>Registro automático de entrada y salida de miembros con historial completo y estadísticas</p>
          </div>

          <div className="feature-card">
            <div className="feature-icon">
              <Calendar size={32} strokeWidth={2} />
            </div>
            <h3>Gestión de Servicios</h3>
            <p>Administra clases grupales, horarios, instructores y capacidad de cada servicio</p>
          </div>

          <div className="feature-card">
            <div className="feature-icon">
              <Shield size={32} strokeWidth={2} />
            </div>
            <h3>Seguridad y Respaldos</h3>
            <p>Encriptación de datos, respaldos automáticos y control de acceso por roles</p>
          </div>
        </div>
      </section>

      {/* Pricing Section */}
      <section className="pricing-section">
        <div className="section-header">
          <span className="section-badge">
            <DollarSign size={18} />
            Planes de Suscripción
          </span>
          <h2>Elige el Plan Perfecto para tu Gimnasio</h2>
          <p>Acceso al software administrativo completo con diferentes opciones de pago</p>
        </div>

        <div className="pricing-grid">
          {plans.map((plan, index) => (
            <div key={index} className={`pricing-card ${plan.popular ? 'popular' : ''}`}>
              {plan.popular && <div className="popular-badge">MÁS POPULAR</div>}
              {plan.save && <div className="save-badge">{plan.save}</div>}

              <div className="plan-header">
                <h3>{plan.name}</h3>
                <div className="plan-price">
                  <span className="price">{plan.price}</span>
                  <span className="period">{plan.period}</span>
                </div>
              </div>

              <ul className="plan-features">
                {plan.features.map((feature, i) => (
                  <li key={i}>
                    <span className="check-icon">
                      <Check size={16} strokeWidth={3} />
                    </span>
                    {feature}
                  </li>
                ))}
              </ul>

              <button
                className={`plan-button ${plan.popular ? 'popular-btn' : ''}`}
                onClick={() => navigate('/register')}
              >
                Comenzar Ahora
              </button>
            </div>
          ))}
        </div>
      </section>

      {/* CTA Section */}
      <section className="cta-section">
        <div className="cta-content">
          <TrendingUp size={48} strokeWidth={2} />
          <h2>¿Listo para Transformar tu Gimnasio?</h2>
          <p>Únete a cientos de gimnasios que ya confían en nuestro sistema administrativo</p>
          <div className="cta-buttons">
            <button className="cta-btn primary" onClick={() => navigate('/register')}>
              Registrarse Gratis
            </button>
            <button className="cta-btn secondary" onClick={() => navigate('/login')}>
              Iniciar Sesión
            </button>
          </div>
        </div>
      </section>

      {/* Footer */}
      <footer className="landing-footer">
        <div className="footer-content">
          <div className="footer-section">
            <h4>TechSoft Solutions</h4>
            <p>Innovación tecnológica para tu negocio</p>
          </div>
          <div className="footer-section">
            <h4>Contacto</h4>
            <p>info@techsoft.com</p>
            <p>+57 300 123 4567</p>
          </div>
          <div className="footer-section">
            <h4>Ubicación</h4>
            <p>Bogotá, Colombia</p>
            <p>Carrera 7 #32-16</p>
          </div>
        </div>
        <div className="footer-bottom">
          <p>&copy; 2025 TechSoft Solutions. Todos los derechos reservados.</p>
        </div>
      </footer>
    </div>
  );
}

export default Landing;

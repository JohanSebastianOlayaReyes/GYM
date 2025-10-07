import { useState } from 'react';
import { Users, CreditCard, DollarSign, Activity, TrendingUp, TrendingDown } from 'lucide-react';
import { PieChart, Pie, Cell, AreaChart, Area, BarChart, Bar, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer, Legend } from 'recharts';
import './Dashboard.css';

function Dashboard({ admin }) {
  const currentDate = new Date();
  const currentMonth = currentDate.getMonth();
  const currentYear = currentDate.getFullYear();
  const [selectedDate, setSelectedDate] = useState(new Date());

  // Datos de estadísticas
  const statsData = [
    { name: 'Clientes', value: 222, color: '#0ea5e9' },
    { name: 'Activos', value: 6, color: '#10b981' },
    { name: 'Inactivos', value: 216, color: '#ef4444' },
  ];

  // Datos para el gráfico de área
  const monthlyData = [
    { month: 'Enero', memberships: 180, payments: 150, attendance: 120 },
    { month: 'Febrero', memberships: 220, payments: 190, attendance: 160 },
    { month: 'Marzo', memberships: 250, payments: 230, attendance: 200 },
    { month: 'Abril', memberships: 280, payments: 260, attendance: 220 },
    { month: 'Mayo', memberships: 230, payments: 210, attendance: 180 },
  ];

  // Datos para el gráfico de barras de ingresos
  const incomeData = [
    { month: 'Ene', income: 3500000 },
    { month: 'Feb', income: 4200000 },
    { month: 'Mar', income: 3800000 },
    { month: 'Abr', income: 5100000 },
    { month: 'May', income: 4500000 },
    { month: 'Jun', income: 4800000 },
    { month: 'Jul', income: 5300000 },
    { month: 'Ago', income: 4900000 },
    { month: 'Sep', income: 5500000 },
    { month: 'Oct', income: 6200000 },
  ];

  // Tarjetas de estadísticas principales
  const mainStats = [
    {
      title: 'Total Miembros',
      value: '444',
      change: '+12%',
      isPositive: true,
      Icon: Users,
      color: '#0ea5e9'
    },
    {
      title: 'Ingresos del Mes',
      value: '$45,230',
      change: '+8%',
      isPositive: true,
      Icon: DollarSign,
      color: '#10b981'
    },
    {
      title: 'Membresías Activas',
      value: '222',
      change: '-3%',
      isPositive: false,
      Icon: CreditCard,
      color: '#f59e0b'
    },
    {
      title: 'Asistencias Hoy',
      value: '89',
      change: '+5%',
      isPositive: true,
      Icon: Activity,
      color: '#8b5cf6'
    },
  ];

  // Generar días del calendario
  const getDaysInMonth = (month, year) => {
    return new Date(year, month + 1, 0).getDate();
  };

  const getFirstDayOfMonth = (month, year) => {
    return new Date(year, month, 1).getDay();
  };

  const generateCalendarDays = () => {
    const daysInMonth = getDaysInMonth(currentMonth, currentYear);
    const firstDay = getFirstDayOfMonth(currentMonth, currentYear);
    const days = [];

    // Días vacíos al inicio
    for (let i = 0; i < firstDay; i++) {
      days.push(null);
    }

    // Días del mes
    for (let i = 1; i <= daysInMonth; i++) {
      days.push(i);
    }

    return days;
  };

  const monthNames = [
    'Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
    'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'
  ];

  const dayNames = ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'];

  return (
    <div className="dashboard-container">
      <div className="dashboard-header">
        <div>
          <h1>Dashboard</h1>
          <p>Bienvenido de vuelta, {admin?.name || 'Administrador'}</p>
        </div>
      </div>

      {/* Tarjetas de Estadísticas Principales */}
      <div className="stats-grid">
        {mainStats.map((stat, index) => (
          <div key={index} className="stat-card-modern">
            <div className="stat-card-header">
              <div className="stat-icon-wrapper" style={{ backgroundColor: `${stat.color}20` }}>
                <stat.Icon size={24} style={{ color: stat.color }} strokeWidth={2} />
              </div>
              <span className={`stat-change ${stat.isPositive ? 'positive' : 'negative'}`}>
                {stat.isPositive ? <TrendingUp size={16} /> : <TrendingDown size={16} />}
                {stat.change}
              </span>
            </div>
            <div className="stat-card-body">
              <h3>{stat.title}</h3>
              <p className="stat-value-large">{stat.value}</p>
            </div>
          </div>
        ))}
      </div>

      {/* Grid de Gráficos */}
      <div className="charts-grid">
        {/* Gráfico Circular de Clientes */}
        <div className="chart-card">
          <div className="chart-header">
            <h2>Estado de Clientes</h2>
          </div>
          <div className="chart-content">
            <div className="pie-chart-container">
              <ResponsiveContainer width="100%" height={200}>
                <PieChart>
                  <Pie
                    data={statsData}
                    cx="50%"
                    cy="50%"
                    innerRadius={60}
                    outerRadius={80}
                    paddingAngle={5}
                    dataKey="value"
                  >
                    {statsData.map((entry, index) => (
                      <Cell key={`cell-${index}`} fill={entry.color} />
                    ))}
                  </Pie>
                </PieChart>
              </ResponsiveContainer>
            </div>
            <div className="pie-legend">
              {statsData.map((item, index) => (
                <div key={index} className="legend-item">
                  <div className="legend-color" style={{ backgroundColor: item.color }}></div>
                  <span className="legend-label">{item.name}</span>
                  <span className="legend-value">{item.value}</span>
                </div>
              ))}
            </div>
          </div>
        </div>

        {/* Gráfico de Área de Estadísticas Mensuales */}
        <div className="chart-card chart-wide">
          <div className="chart-header">
            <h2>Estadísticas Mensuales</h2>
          </div>
          <div className="chart-content">
            <ResponsiveContainer width="100%" height={280}>
              <AreaChart data={monthlyData}>
                <defs>
                  <linearGradient id="colorMemberships" x1="0" y1="0" x2="0" y2="1">
                    <stop offset="5%" stopColor="#0ea5e9" stopOpacity={0.8}/>
                    <stop offset="95%" stopColor="#0ea5e9" stopOpacity={0.1}/>
                  </linearGradient>
                  <linearGradient id="colorPayments" x1="0" y1="0" x2="0" y2="1">
                    <stop offset="5%" stopColor="#10b981" stopOpacity={0.8}/>
                    <stop offset="95%" stopColor="#10b981" stopOpacity={0.1}/>
                  </linearGradient>
                  <linearGradient id="colorAttendance" x1="0" y1="0" x2="0" y2="1">
                    <stop offset="5%" stopColor="#8b5cf6" stopOpacity={0.8}/>
                    <stop offset="95%" stopColor="#8b5cf6" stopOpacity={0.1}/>
                  </linearGradient>
                </defs>
                <CartesianGrid strokeDasharray="3 3" stroke="#e5e7eb" />
                <XAxis dataKey="month" stroke="#6b7280" style={{ fontSize: '12px' }} />
                <YAxis stroke="#6b7280" style={{ fontSize: '12px' }} />
                <Tooltip
                  contentStyle={{
                    backgroundColor: '#fff',
                    border: '1px solid #e5e7eb',
                    borderRadius: '8px',
                    boxShadow: '0 4px 6px rgba(0,0,0,0.1)'
                  }}
                />
                <Area
                  type="monotone"
                  dataKey="memberships"
                  stroke="#0ea5e9"
                  strokeWidth={2}
                  fillOpacity={1}
                  fill="url(#colorMemberships)"
                  name="Membresías"
                />
                <Area
                  type="monotone"
                  dataKey="payments"
                  stroke="#10b981"
                  strokeWidth={2}
                  fillOpacity={1}
                  fill="url(#colorPayments)"
                  name="Pagos"
                />
                <Area
                  type="monotone"
                  dataKey="attendance"
                  stroke="#8b5cf6"
                  strokeWidth={2}
                  fillOpacity={1}
                  fill="url(#colorAttendance)"
                  name="Asistencias"
                />
              </AreaChart>
            </ResponsiveContainer>
          </div>
        </div>

        {/* Gráfico de Barras de Ingresos Mensuales */}
        <div className="chart-card chart-wide">
          <div className="chart-header">
            <h2>Ingresos Mensuales</h2>
            <p className="chart-subtitle">Ingresos generados por mes (COP)</p>
          </div>
          <div className="chart-content">
            <ResponsiveContainer width="100%" height={300}>
              <BarChart data={incomeData}>
                <defs>
                  <linearGradient id="colorIncome" x1="0" y1="0" x2="0" y2="1">
                    <stop offset="5%" stopColor="#10b981" stopOpacity={0.9}/>
                    <stop offset="95%" stopColor="#10b981" stopOpacity={0.6}/>
                  </linearGradient>
                </defs>
                <CartesianGrid strokeDasharray="3 3" stroke="#e5e7eb" />
                <XAxis
                  dataKey="month"
                  stroke="#6b7280"
                  style={{ fontSize: '12px' }}
                />
                <YAxis
                  stroke="#6b7280"
                  style={{ fontSize: '12px' }}
                  tickFormatter={(value) => `$${(value / 1000000).toFixed(1)}M`}
                />
                <Tooltip
                  contentStyle={{
                    backgroundColor: '#fff',
                    border: '1px solid #e5e7eb',
                    borderRadius: '8px',
                    boxShadow: '0 4px 6px rgba(0,0,0,0.1)'
                  }}
                  formatter={(value) => [`$${value.toLocaleString('es-CO')}`, 'Ingresos']}
                  labelStyle={{ fontWeight: 'bold', color: '#1f2937' }}
                />
                <Bar
                  dataKey="income"
                  fill="url(#colorIncome)"
                  radius={[8, 8, 0, 0]}
                  name="Ingresos"
                />
              </BarChart>
            </ResponsiveContainer>
          </div>
        </div>

        {/* Calendario */}
        <div className="chart-card">
          <div className="calendar-header">
            <h2>{monthNames[currentMonth]} {currentYear}</h2>
          </div>
          <div className="calendar-container">
            <div className="calendar-days-header">
              {dayNames.map((day, index) => (
                <div key={index} className="calendar-day-name">{day}</div>
              ))}
            </div>
            <div className="calendar-days-grid">
              {generateCalendarDays().map((day, index) => (
                <div
                  key={index}
                  className={`calendar-day ${day === null ? 'empty' : ''} ${
                    day === currentDate.getDate() ? 'today' : ''
                  }`}
                  onClick={() => day && setSelectedDate(new Date(currentYear, currentMonth, day))}
                >
                  {day}
                </div>
              ))}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Dashboard;

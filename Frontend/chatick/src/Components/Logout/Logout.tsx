import {useNavigate} from 'react-router-dom';

const Logout = () => {
  const navigate = useNavigate();

  const handleLogOut = () => {
    localStorage.setItem('token', '');
    localStorage.clear();
    navigate('/login');
  };

  return (
    <button type="button" onClick={handleLogOut}>
      Logout
    </button>
  );
};

export default Logout;

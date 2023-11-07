import { CreateCalculationsForPrimarySchool } from "./components/Calculations";
import { FetchData } from "./components/FetchData";
import { Main } from "./components/Main"
import { Login } from "./components/Login";
import { Register } from "./components/Register";


const AppRoutes = [
  {
    index: true,
    element: <Login />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  {
    path: '/Calculations',
    element: <CreateCalculationsForPrimarySchool />
  },
  {
    path: '/Main',
    element: <Main/>
  },
  {
    path: '/Register',
    elemnt: <Register/>
  }
];

export default AppRoutes;

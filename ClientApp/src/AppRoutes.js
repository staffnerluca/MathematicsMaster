import { CreateCalculationsForPrimarySchool } from "./components/Calculations";
import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { Main } from "./components/Main"
import { Login } from "./components/Login";

const AppRoutes = [
  {
    index: true,
    element: <Login />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  {
    path: 'Calculations',
    element: <CreateCalculationsForPrimarySchool />
  },
  {
    path: 'Main',
    element: <Main/>
  }
];

export default AppRoutes;

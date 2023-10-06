import { CreateCalculationsForPrimarySchool } from "./components/Calculations";
import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";

const AppRoutes = [
  {
    index: true,
    element: <Home />
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
  }
];

export default AppRoutes;

import { CreateCalculationsForPrimarySchool } from "./components/Calculations";
import { FetchData } from "./components/FetchData";
import { Main } from "./components/Main"
import { Login } from "./components/Login";
import { Register } from "./components/Register";
import { StrengthsWeaknesses } from "./components/StrengthsWeaknesses"
import { UserSettings } from "./components/UserSettings"

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
    path: "/StrengthsWeaknesses",
    element: <StrengthsWeaknesses/>
  },
  {
    path: "/Register",
    element: <Register />
  },
  {
    path: "/Settings",
    element: <UserSettings/>
  }
];

export default AppRoutes;

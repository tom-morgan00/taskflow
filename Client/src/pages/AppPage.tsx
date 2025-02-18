import AppLayout from "../layout/AppLayout";
import { Outlet } from "react-router";

export default function AppPage() {
  return (
    <AppLayout>
      <Outlet />
    </AppLayout>
  );
}

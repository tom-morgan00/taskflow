import { createBrowserRouter, Link } from "react-router";
import AppPage from "@/pages/AppPage";
import AuthPage from "@/pages/AuthPage";
import LoginForm from "@/components/features/auth/LoginForm";
import SignupForm from "@/components/features/auth/SignupForm";
import ForgotPasswordForm from "@/components/features/auth/ForgotPasswordForm";
import WorkspaceList from "@/components/features/workspaces/WorkspaceList";
import WorkspaceView from "@/components/features/workspaces/WorkspaceView";
import BearTest from "@/components/features/BearTest";
import Logout from "@/components/features/auth/Logout";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <>Home Page</>,
  },
  {
    path: "/auth/",
    element: <AuthPage />,
    children: [
      { path: "login", element: <LoginForm /> },
      { path: "signup", element: <SignupForm /> },
      { path: "forgot-password", element: <ForgotPasswordForm /> },
      { path: "reset-password", element: <>Reset password</> },
      {
        path: "logout",
        element: <Logout />,
      },
    ],
  },
  {
    path: "/app/",
    element: <AppPage />,
    children: [
      { path: "", element: <>Dashboard</> },
      { path: "my-tasks", element: <>My Tasks</> },
      { path: "bears", element: <BearTest /> },
      { path: "workspaces/", element: <WorkspaceList /> },
      { path: "workspaces/:id", element: <WorkspaceView /> },
      { path: "notifications/", element: <>Notifications</> },
      { path: "account/", element: <>Account</> },
    ],
  },
]);

import { createBrowserRouter, Link } from "react-router";
import AppPage from "@/pages/AppPage";
import AuthPage from "@/pages/AuthPage";
import LoginForm from "@/components/features/auth/LoginForm";
import SignupForm from "@/components/features/auth/SignupForm";
import ForgotPasswordForm from "@/components/features/auth/ForgotPasswordForm";
import WorkspaceList from "@/components/features/workspaces/WorkspaceList";
import WorkspaceView from "@/components/features/workspaces/WorkspaceView";

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
        element: (
          <div className="flex flex-col gap-2 items-center">
            <h1 className="text-2xl font-bold">Logging out...</h1>
            <Link to="/auth/login" className="underline underline-offset-4">
              Log in
            </Link>
          </div>
        ),
      },
    ],
  },
  {
    path: "/app/",
    element: <AppPage />,
    children: [
      { path: "", element: <>Dashboard</> },
      { path: "my-tasks", element: <>My Tasks</> },
      { path: "workspaces/", element: <WorkspaceList /> },
      { path: "workspaces/:id", element: <WorkspaceView /> },
      { path: "notifications/", element: <>Notifications</> },
      { path: "account/", element: <>Account</> },
    ],
  },
]);

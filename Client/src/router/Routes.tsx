import { createBrowserRouter, Link } from "react-router";
import AppPage from "@/app/AppPage";
import AuthPage from "@/app/AuthPage";
import { LoginForm } from "@/components/login-form";
import { SignupForm } from "@/components/signup-form";
import { ForgotPasswordForm } from "@/components/forgot-password-form";

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
          <>
            Logging out...<Link to="/auth/login">Log in</Link>
          </>
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
      { path: "workspaces/", element: <>Workspaces</> },
      { path: "workspaces/:id", element: <>Workspace Tasks</> },
      { path: "notifications/", element: <>Notifications</> },
      { path: "account/", element: <>Account</> },
    ],
  },
]);

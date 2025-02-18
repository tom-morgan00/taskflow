import {
  CheckCircle,
  ClipboardList,
  Command,
  LayoutDashboard,
} from "lucide-react";

import NavMain from "@/components/features/navigation/NavMain";
import NavUser from "@/components/features/navigation/NavUser";
import {
  Sidebar,
  SidebarContent,
  SidebarFooter,
  SidebarHeader,
  SidebarMenu,
  SidebarMenuButton,
  SidebarMenuItem,
} from "@/components/ui/sidebar";
import { Link } from "react-router";
import useWorkspaces from "@/lib/hooks/useWorkspaces";

export default function AppSidebar({
  ...props
}: React.ComponentProps<typeof Sidebar>) {
  const { workspaces } = useWorkspaces();

  const data = {
    user: {
      name: "shadcn",
      email: "m@example.com",
      avatar: "/avatars/shadcn.jpg",
    },
    navMain: [
      {
        title: "Dashboard",
        url: "/app",
        icon: LayoutDashboard,
        isActive: true,
      },
      {
        title: "My Tasks",
        url: "/app/my-tasks",
        icon: CheckCircle,
        isActive: false,
      },
      {
        title: "Workspaces",
        url: "/app/workspaces",
        icon: ClipboardList,
        isActive: false,
        items:
          workspaces?.data?.map((workspace) => ({
            title: workspace.name,
            url: `/app/workspaces/${workspace.id}`,
          })) || [],
      },
    ],
    // navSecondary: [
    //   {
    //     title: "Support",
    //     url: "#",
    //     icon: LifeBuoy,
    //   },
    //   {
    //     title: "Feedback",
    //     url: "#",
    //     icon: Send,
    //   },
    // ],
  };
  return (
    <Sidebar variant="inset" {...props}>
      <SidebarHeader>
        <SidebarMenu>
          <SidebarMenuItem>
            <SidebarMenuButton size="lg" asChild>
              <Link to="/app">
                <div className="bg-sidebar-primary text-sidebar-primary-foreground flex aspect-square size-8 items-center justify-center rounded-lg">
                  <Command className="size-4" />
                </div>
                <div className="grid flex-1 text-left text-sm leading-tight">
                  <span className="truncate font-semibold">Acme Inc</span>
                  <span className="truncate text-xs">Enterprise</span>
                </div>
              </Link>
            </SidebarMenuButton>
          </SidebarMenuItem>
        </SidebarMenu>
      </SidebarHeader>
      <SidebarContent>
        <NavMain items={data.navMain} />
        {/* <NavSecondary items={data.navSecondary} className="mt-auto" /> */}
      </SidebarContent>
      <SidebarFooter>
        <NavUser user={data.user} />
      </SidebarFooter>
    </Sidebar>
  );
}

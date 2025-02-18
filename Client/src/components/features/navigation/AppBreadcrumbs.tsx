import { Link, useLocation } from "react-router";
import {
  Breadcrumb,
  BreadcrumbItem,
  BreadcrumbLink,
  BreadcrumbList,
  BreadcrumbSeparator,
} from "@/components/ui/breadcrumb";

export default function Breadcrumbs() {
  const location = useLocation();

  const pathArray =
    location.pathname.split("/").slice(2).length > 0
      ? location.pathname.split("/").slice(2)
      : location.pathname.split("/").slice(1);

  return (
    <Breadcrumb>
      <BreadcrumbList>
        {pathArray.map((segment, index) => {
          const fullPath = pathArray.slice(0, index + 1).join("/");
          const isLast = index === pathArray.length - 1;

          return (
            <BreadcrumbItem key={fullPath}>
              {isLast ? (
                <span className="text-gray-800">
                  {formatBreadcrumb(segment)}
                </span>
              ) : (
                <BreadcrumbLink asChild>
                  <Link to={fullPath}>{formatBreadcrumb(segment)}</Link>
                </BreadcrumbLink>
              )}
              {!isLast && <BreadcrumbSeparator />}
            </BreadcrumbItem>
          );
        })}
      </BreadcrumbList>
    </Breadcrumb>
  );
}

// Convert path segments into readable names
function formatBreadcrumb(segment: string): string {
  if (segment.match(/^[0-9a-fA-F-]{36}$/)) return "Workspace 1"; // Example for UUIDs
  return segment
    .replace(/-/g, " ")
    .replace(/\b\w/g, (char) => char.toUpperCase());
}

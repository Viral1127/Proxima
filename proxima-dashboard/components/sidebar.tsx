"use client"

import { useState } from "react"
import Link from "next/link"
import { Button } from "@/components/ui/button"
import { cn } from "@/lib/utils"
import { BarChart2, Briefcase, Calendar, CheckSquare, Clock, FileText, Home, Plus, Settings, Users, ChevronLeft, ChevronRight } from 'lucide-react'

const navigation = [
  { name: "Home", href: "/dashboard", icon: Home },
  { name: "My Work", href: "/my-work", icon: CheckSquare },
  { name: "Projects", href: "/projects", icon: Briefcase },
  { name: "Calendar", href: "/calendar", icon: Calendar },
  { name: "Timeline", href: "/timeline", icon: Clock },
  { name: "Reports", href: "/reports", icon: BarChart2 },
  { name: "Documents", href: "/documents", icon: FileText },
  { name: "Teams", href: "/teams", icon: Users },
]

export function Sidebar() {
  const [isCollapsed, setIsCollapsed] = useState(true)
  const [isHovered, setIsHovered] = useState(false)

  const expanded = !isCollapsed || isHovered

  return (
    <div
      className={cn(
        "fixed inset-y-0 z-40 flex flex-col transition-all duration-300 ease-in-out",
        expanded ? "w-64" : "w-16"
      )}
      onMouseEnter={() => setIsHovered(true)}
      onMouseLeave={() => setIsHovered(false)}
    >
      <div className="flex grow flex-col gap-y-5 overflow-hidden border-r bg-white pb-4">
        <div className="flex h-16 shrink-0 items-center justify-between px-4">
          <span className={cn(
            "text-xl font-bold transition-opacity duration-300",
            expanded ? "opacity-100" : "opacity-0"
          )}>
            proxima
          </span>
          <Button
            variant="ghost"
            size="icon"
            className={cn(
              "transition-opacity duration-300",
              expanded ? "opacity-100" : "opacity-0"
            )}
            onClick={() => setIsCollapsed(!isCollapsed)}
          >
            {isCollapsed ? <ChevronRight className="h-4 w-4" /> : <ChevronLeft className="h-4 w-4" />}
          </Button>
        </div>
        <div className="px-4">
          <Button className={cn(
            "justify-start gap-2 w-full transition-all duration-300",
            !expanded && "px-0 justify-center"
          )}>
            <Plus className="h-4 w-4" />
            <span className={cn(
              "transition-opacity duration-300",
              expanded ? "opacity-100" : "opacity-0 w-0"
            )}>
              Add New
            </span>
          </Button>
        </div>
        <nav className="flex flex-1 flex-col">
          <ul role="list" className="flex flex-1 flex-col gap-y-7">
            <li>
              <ul role="list" className="space-y-1 px-4">
                {navigation.map((item) => (
                  <li key={item.name}>
                    <Link
                      href={item.href}
                      className={cn(
                        "text-gray-700 hover:text-blue-600 hover:bg-gray-50 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold transition-all duration-300",
                        !expanded && "justify-center"
                      )}
                    >
                      <item.icon className="h-5 w-5 shrink-0" />
                      <span className={cn(
                        "transition-opacity duration-300",
                        expanded ? "opacity-100" : "opacity-0 w-0 hidden"
                      )}>
                        {item.name}
                      </span>
                    </Link>
                  </li>
                ))}
              </ul>
            </li>
            <li className="mt-auto px-4">
              <Link
                href="/settings"
                className={cn(
                  "text-gray-700 hover:text-blue-600 hover:bg-gray-50 group flex gap-x-3 rounded-md p-2 text-sm leading-6 font-semibold transition-all duration-300",
                  !expanded && "justify-center"
                )}
              >
                <Settings className="h-5 w-5 shrink-0" />
                <span className={cn(
                  "transition-opacity duration-300",
                  expanded ? "opacity-100" : "opacity-0 w-0 hidden"
                )}>
                  Settings
                </span>
              </Link>
            </li>
          </ul>
        </nav>
      </div>
    </div>
  )
}


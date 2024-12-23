"use client"

import { useState } from "react"
import { Header } from "@/components/header"
import { Sidebar } from "@/components/sidebar"
import { Card, CardContent } from "@/components/ui/card"
import { Button } from "@/components/ui/button"
import { Calendar } from "@/components/ui/calendar"
import { Badge } from "@/components/ui/badge"
import { ChevronLeft, ChevronRight, PlusCircle } from 'lucide-react'

export default function CalendarPage() {
  const [date, setDate] = useState<Date | undefined>(new Date())

  const events = [
    { id: 1, title: "Team Meeting", date: new Date(2023, 9, 15), type: "meeting" },
    { id: 2, title: "Project Deadline", date: new Date(2023, 9, 20), type: "deadline" },
    { id: 3, title: "Client Presentation", date: new Date(2023, 9, 25), type: "presentation" },
  ]

  return (
    <div className="flex min-h-screen bg-gray-50">
      <Sidebar />
      <div className="flex-1 flex flex-col pl-16">
        <Header />
        <main className="flex-1 overflow-x-auto p-6">
          <div className="max-w-6xl mx-auto space-y-6">
            <div className="flex justify-between items-center">
              <h1 className="text-2xl font-semibold text-gray-900">Calendar</h1>
              <Button>
                <PlusCircle className="mr-2 h-4 w-4" />
                Add Event
              </Button>
            </div>
            <div className="grid grid-cols-1 lg:grid-cols-3 gap-6">
              <Card className="lg:col-span-2">
                <CardContent className="p-0">
                  <Calendar
                    mode="single"
                    selected={date}
                    onSelect={setDate}
                    className="rounded-md border"
                  />
                </CardContent>
              </Card>
              <Card>
                <CardContent>
                  <h2 className="text-lg font-semibold mb-4">Upcoming Events</h2>
                  <ul className="space-y-4">
                    {events.map((event) => (
                      <li key={event.id} className="flex items-center justify-between">
                        <div>
                          <p className="font-medium">{event.title}</p>
                          <p className="text-sm text-gray-500">
                            {event.date.toLocaleDateString()}
                          </p>
                        </div>
                        <Badge variant={
                          event.type === "meeting" ? "default" :
                          event.type === "deadline" ? "destructive" :
                          "outline"
                        }>
                          {event.type}
                        </Badge>
                      </li>
                    ))}
                  </ul>
                </CardContent>
              </Card>
            </div>
          </div>
        </main>
      </div>
    </div>
  )
}


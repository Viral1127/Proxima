import { NextResponse } from 'next/server'

export async function GET(request: Request) {
  const { searchParams } = new URL(request.url)
  const secret = searchParams.get('secret')

  if (secret !== 'MY_SECRET_TOKEN') {
    return NextResponse.json({ message: 'Invalid token' }, { status: 401 })
  }

  const res = NextResponse.next()
  res.cookies.set('__prerender_bypass', process.env.PRERENDER_BYPASS_TOKEN || '')
  res.cookies.set('__next_preview_data', process.env.PREVIEW_DATA_TOKEN || '')

  return res
}


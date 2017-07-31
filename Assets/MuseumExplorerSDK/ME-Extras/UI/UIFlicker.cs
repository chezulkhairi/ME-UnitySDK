﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Helpers.Extensions;

[RequireComponent(typeof(Graphic))]
public class UIFlicker : MonoBehaviour
{
    public float minAlpha = 0;
    public float maxAlpha = 1;
    public float fadeInTime = 0.5f;
    public float fadeOutTime = 0.5f;
    public float waitBetweenTime = 1;
    public bool fadeOutOnStart;
    public bool fadeIn;
    public bool fadeOut;

    public bool IsFlickering { get { return flickerRoutine != null; } }

    private Graphic graphic;
    private Coroutine flickerRoutine;

    void Start()
    {
        graphic = GetComponent<Graphic>();
        if (fadeOutOnStart)
        {
            Hide(instant: false);
        }
    }

    void Update()
    {
        if (fadeIn)
        {
            Show(instant: false);
            fadeIn = false;
        }
        if (fadeOut)
        {
            Hide(instant: false);
            fadeOut = false;
        }
    }

    public void Hide(bool instant = false)
    {
        if (IsFlickering) { StopFlickering(); }
        graphic.CrossFadeAlpha(0, instant ? 0 : fadeOutTime, ignoreTimeScale: true);
    }

    public void Show(bool instant = false)
    {
        if (IsFlickering) { StopFlickering(); }
        graphic.CrossFadeAlpha(maxAlpha, instant ? 0 : fadeInTime, ignoreTimeScale: true);
    }

    public void Flicker(Graphic graphic = null)
    {
        if (flickerRoutine != null)
        {
            StopCoroutine(flickerRoutine);
            flickerRoutine = null;
        }
        if (graphic != null)
        {
            this.graphic = graphic;
        }
        flickerRoutine = StartCoroutine(FlickerRoutine());
    }

    public void StopFlickering(bool fadeInWhenDone = false, bool fadeOutWhenDone = false, float? targetAlpha = null)
    {
        if (flickerRoutine != null)
        {
            StopCoroutine(flickerRoutine);
            flickerRoutine = null;
        }
        if (fadeOutWhenDone)
        {
            targetAlpha = targetAlpha ?? 0;
            graphic.CrossFadeAlpha(targetAlpha.Value, fadeOutTime, ignoreTimeScale: true);
        }
        else if (fadeInWhenDone)
        {
            targetAlpha = targetAlpha ?? maxAlpha;
            graphic.CrossFadeAlpha(targetAlpha.Value, fadeOutTime, ignoreTimeScale: true);
        }
    }

    private IEnumerator FlickerRoutine()
    {
        while (true)
        {
            graphic.CrossFadeAlpha(maxAlpha, fadeInTime, ignoreTimeScale: true);
            yield return new WaitForSeconds(waitBetweenTime);
            graphic.CrossFadeAlpha(minAlpha, fadeOutTime, ignoreTimeScale: true);
            yield return new WaitForSeconds(waitBetweenTime);
        }
        // flickerRoutine = null;
    }
}
